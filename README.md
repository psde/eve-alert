eve-alert
=========

Monitors an EVE-Online intel channel and character gamelogs for status on systems and incoming/outgoing damage notifications. It will alert the user under different conditions with playing a sound and/or showing a notification onscreen.

Please make sure to init the git submodules.

Todo
----

- Improve heuristic, switch to regular expressions
- Add functionality to configure keywords to look out for in the gamelog (valuable NPCs like 'Gurista Dread')
- Use EasyHooks D3D-Hook to mimic OnScreenReplica

Thanks
------

Thanks to ben0x539/eve-log-alert for the general idea.