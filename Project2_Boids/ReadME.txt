/*
 
 * Christian Barajas
 
 * Project_2: Boids
 
 * Spring 2017
 
 * CS 596
 
 */


Project_2:

**Updates**
- Everything is pushed including GDD & TDD.


Notes about Flock:
- When scene is first loaded, fish are in circle a tree mode around origin. 
- When fish are in circle a tree mode, they are doing a small circle to mimick how fish mate. 
- Everytime flock enters circle a tree mode, fish will circle around whatever position the center of the group is at that moment in time.
- When flock enters lazy flight mode, fish will swim randomly within scene. The less total number of fish there are in the scene, the more
  random the behavior becomes. For example, if group size is 10, a group of fish may form but a few fish might swim off on their own to mimick 
  real random behaviors of fish. The more fish in the scene, the harder it is to point out which fish are within a group and which are off on their own.
- When flocks enter follow the leader mode, the fish will follow a waypoint represented as a green cube.
- The green cube will always be on the scene. But the green cube will only affect the flock in Follow the leader mode. 