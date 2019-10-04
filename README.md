# ARFoundation_PostProcessing

Example project showing off how post processing can be applied to mobile AR.

Depth of Field based Blur for objects
![gif](https://i.imgur.com/7XfaDYa.gif)

Motion blur
![gif](https://i.imgur.com/To1LeLY.gif)

-------------------
**Current Unity version: 2019.3.0b1**

Built using preview packages for ARFoundation and ARKit **package versions: 3.0.0 -preview.2**

Using unity post processing **package version 2.1.7**

-------------------

This project uses Grain, Motion Blur and Depth of Field. The grain and motion blur are set values in the editor and the depth of field is driven by values from the Camera Intrinsics.


The blur effect in this project is driven by Camera Intrinsics https://developer.apple.com/documentation/arkit/arcamera/2875730-intrinsics which is a feature specific for ARKit and iOS platform.


-------------------










The core of this project is built from AR Foundation samples https://github.com/Unity-Technologies/arfoundation-samples which is copyright © 2019 Unity Technologies ApS
