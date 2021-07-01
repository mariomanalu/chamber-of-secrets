// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// To add a new field to the Field Library, follow these steps:
//   1) Create a new function in the field library file. DO NOT change the parameters 
//      or return type. 
//   2) Add a new kernel to VectorCompute.compute by adding the line
//          #pragma kernel [your class name]Field
//      at the top of the file and add the line
//          KERNEL_NAME([your class name])
//      at the bottom of the file. 
//   3) Add the name you want displayed for your field to the `enum FieldType` list
//      in VectorFields.cs. MAKE SURE that the order of this list is the same as the
//      order of the lines at the top of VectorCompute.compute. 
// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
#define PI 3.14159265358979323846
float3 Outwards(float3 position)
{
    return position;
};



float3 Swirl(float3 position)
{
    float3 val;
    val.x = -position.z;
    val.y = 0;
    val.z = position.x;
    return val;
};



float3 Coulomb(float3 position)
{
    float3 vect = float3(0.0, 0.0, 0.0);
    // The first argument in _FloatArgs is the number of charges in the system
    float numCharges = _FloatArgs[0]; 
    float i;
    for (i = 1.0; i < 3.0; i++) // numCharges + 0.0; i++)
    {
        // The zeroth index of _VectorArgs is unused so that the two buffers align.
        float3 displacement = position - _VectorArgs[i] + _CenterPosition;
        float distance = sqrt(displacement.x * displacement.x +
                displacement.y * displacement.y +
                displacement.z * displacement.z);
        vect += _FloatArgs[i] / (pow(distance, 3) + 0.0000000001) * displacement;
    }
    //vect.x += numCharges;
    return vect;
    //return float3(0.0, numCharges, 0.0);
};

float3 Db(float3 position, int index){
    float3 fieldPast = _MagneticFieldPast[index];
    float3 field = Coulomb(position);
    
    float3 diff = field - fieldPast;
    float3 vect =  diff / (_TimeInterval);
    _MagneticFieldPast[index] = field;
    //float3 weightedVect = 0.04 * vect + 0.96 * _DbDtPast[index]; // fine-tune this later. 
    

    //_DbDtPast[index] = weightedVect;
    
    return vect;
    
};

float3 Integrand(float3 position, int index){
    float3 DbDt = Db(position, index);

    float3 distance = position - _Positions[index];
    float distanceCubed = pow(length(distance), 3);

    float3 integrand = cross(DbDt, distance)/distanceCubed;
    return integrand;
};

float3 Electric(float3 position, int index){;

    // Doing the integrand calculation
    int i;
    for (i = 0; i < _NumberOfPoints; i++){
        _Integrand[i] = Integrand(position, i);
    }

    // The Riemann sum
    int j;
    float3 resultNow = float3(0.0, 0.0, 0.0);
    for (j = 0; j < _NumberOfPoints; j++){
        resultNow += _Integrand[j] * 0.0001;
    }

    resultNow = resultNow * (-1 / (4 * PI));
    float3 weightedResult = (0.1 * resultNow) + (0.90 * _IntegrandPast[index]);

    if (weightedResult.x < 0.1 && weightedResult.y < 0.1 && weightedResult.z < 0.1){
        weightedResult = float3(0.0, 0.0, 0.0);
    }
    _IntegrandPast[index] = weightedResult;

    return weightedResult;
    
};
// Every type that's added must also be present in the enum in VectorFields.cs and have a kernel in VectorCompute.compute

