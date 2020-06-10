#!/usr/bin/env python3

import sys,os
import getkey
import numpy as np
from mlagents_envs.environment import UnityEnvironment

def main():
    # This is a non-blocking call that only loads the environment.
    env = UnityEnvironment(file_name=None, seed=1, side_channels=[])
    # Start interacting with the evironment.
    env.reset()
    print("connected")
    names = env.get_behavior_names()
    spec = env.get_behavior_spec(names[0])
    while True:
        env.step()
        dec,ter = env.get_steps(names[0])
        c=getkey.getkey(blocking=True)
        dir = [0.0,0.0]
        if c == 'q':
            print('quitting')
            break
        if len(dec) == 0:
            print('empty')
            continue
        if c == 'w':
            dir[0]=1.0
        elif c == 's':
            dir[0]=-1.0
        elif c == 'a':
            dir[1]=-1.0
        elif c == 'd':
            dir[1]=1.0
        env.set_action_for_agent(names[0],0,np.array(dir))
    return 0

if "__main__" == __name__:
    sys.exit(main())
