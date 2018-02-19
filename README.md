# VoronoiLib
This is a fork of Zalgo2462's VoronoiLib that uses structs and object pooling to avoid the garbage collector at all costs.

Used for an Android Monogame project, where GC calls can cause a noticable stutter. Opted to fork instead of creating a pull request since this is a these changes solve a very specific use case's problem at the cost of making the code less elegant in places.

[Original version here](https://github.com/Zalgo2462/VoronoiLib)