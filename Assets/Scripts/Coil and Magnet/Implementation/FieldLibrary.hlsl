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
float3 Outwards(float3 position, int index)
{
    //return position;
    //float3 vect = position - (_VectorArgs[1.0] - _CenterPosition);
    return position;
};



float3 Swirl(float3 position, int index)
{
    float3 val;
    val.x = -position.z;
    val.y = 0;
    val.z = position.x;
    return val;
};



float3 Coulomb(float3 position, int index)
{
    float3 vect = float3(0.0, 0.0, 0.0);
    // The first argument in _FloatArgs is the number of charges in the system
    float numCharges = _FloatArgs[0]; 
    float i;
    for (i = 1.0; i < 3.0; i++) // numCharges + 0.0; i++)
    {
        // The zeroth index of _VectorArgs is unused so that the two buffers align.
        float3 displacement = position - (_VectorArgs[i] - _CenterPosition);
        float distance = sqrt(displacement.x * displacement.x +
                displacement.y * displacement.y +
                displacement.z * displacement.z);
        vect += _FloatArgs[i] / (pow(distance, 3)) * displacement;
        
    }
   
    return vect;
};

float3 Db(float3 position, int index){
    float3 fieldPast = _MagneticFieldPast[index];
    float3 field = Coulomb(position, index);
    
    float3 diff = field - fieldPast;
    float3 vect =  diff / (_TimeInterval);
    _MagneticFieldPast[index] = field;
    
    // Maybe not necessary
    // if (vect.z < 0.00001 && vect.z > -0.00001){
    //     vect.z = 0.0;
    // }
   
    return vect;
};

// PROBLEM HERE IS THAT DISTANCE IS ALWAYS ZERO

float3 Integrand(float3 position, int index){
    float3 offset = float3(0.0, 0.0, 0.0); // Check if this is necessary in the future
    float3 DbDt = Db(_Positions[index] - _CenterPosition, index);
    
    //return DbDt;
    float3 distance = position - _Positions[index] + _CenterPosition + offset;
    if (length(distance) == 0){
        return offset;
    }
    float distanceCubed = pow(length(distance), 3);
    //float3 dummy = float3(length(distance.x), length(distance.y), length(distance.z));
    //return  -_Positions[index] + _CenterPosition;
    float3 integrand = cross(DbDt, distance)/distanceCubed;
    // integrand.x = DbDt.y * distance.z - distance.y * DbDt.z;
    // integrand.y = DbDt.z * distance.x - distance.z * DbDt.x;
    // integrand.z = DbDt.x * distance.y - distance.x * DbDt.y;
    //integrand = integrand/distanceCubed;
   
    return integrand;
};

// Riemann's sum
// float3 Electric(float3 position, int index){;

//     // Doing the integrand calculation
//     // int i;
//     // for (i = 0; i < _NumberOfPoints; i++){
//     //     _Integrand[i] = Integrand(position, i);
//     // }

//     // The Riemann sum
//     int j;
//     float3 resultNow = float3(0.0, 0.0, 0.0);
//     for (j = 0; j < _NumberOfPoints; j++){
//         resultNow += Integrand(position, j) * 0.001 * 1000; // 0.001 is the "volume" and 1000 is the extra scaling factor
//     }

//     resultNow = resultNow * (-1 / (4 * PI));
//     //float3 weightedResult = (0.1 * resultNow) + (0.90 * _IntegrandPast[index]);

//     // if (weightedResult.x < 0.1 && weightedResult.y < 0.1 && weightedResult.z < 0.1){
//     //     weightedResult = float3(0.0, 0.0, 0.0);
//     // }
//     //_IntegrandPast[index] = weightedResult;

//     return resultNow;
    
// };
// Every type that's added must also be present in the enum in VectorFields.cs and have a kernel in VectorCompute.compute

