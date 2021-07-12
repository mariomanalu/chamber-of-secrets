# Vector Field in VR

### Problem
In teaching about vectors, instructors typically ask students to picture an arrow that points in a certain direction and has a certain length. Now a vector field is an assignment of a vector at every point in a space, varying continuously. Typically, a new learner is presented with two-dimensional pictures with a collection of arrows representing the value of the vector field at a sample of points. When students first encounter vector fields, they often struggle, as the pictures are very different from the pictures of graphs of functions they are used to; frequently these pictures only compound the confusion. 

### Proposed Solution
My game will help solve the problem by allowing students to "live" in the vector field itself. I am using the concept of electromagnetic field to explain how vector field behaves in three-dimensional space. The player will have the ability to grab a bar magnet and move it to generate a magnetic field, which in turns, will create an electric field. I use Unity and C# to build the game. There is a lot of computation needed for the game, especially when it tries to compute a triple-integral to generate an electric field. Thus, I learn and make use of HLSL and Compute Shader to let the GPU do the computation. As a result, the game is three times faster than its previous version.
