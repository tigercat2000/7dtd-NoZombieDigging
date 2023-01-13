# No Zombie Digging
## By Tigercat2000
## For Alpha 20

For the miners like me who are damn tired of zombies scratching at the ground, as well as the bunker builders.

This mod prevents zombie AI from deciding to dig into the ground or target terrain blocks. 

Zombies still can and will attack all other blocks as normal to get to heat or players. 

## Technical Details

This is a [Harmony](https://github.com/BepInEx/HarmonyX) mod that overrides `EntityMoveHelper::DigStart` and `EAIBreakBlock::CanExecute`.

`EntityMoveHelper::DigStart` is responsible for setting up zombies to dig downwards towards a heat source and make tunnels;
by overriding it and making it do nothing, zombies will resort to other behavior.

`EAIBreakBlock::CanExecute` is responsible for all "obstacle in way, attack block?" logic; this is more
subtly overridden to check if the targeted block is any type of terrain, and then returns false, forcing the AI 
to move to the next task.

## Limitations

Because I'm lazy and for no other reason, this doesn't prevent zombies from damaging terrain incidentally.

If you build a dirt tower for instance, and the zombie tries to swing at *you*, but misses and hits the dirt
below you, it'll still damage it. 

This can be fixed by either overriding Block::OnBlockDamaged, or, easier but more tedious, setting up an items.xml override to add entries
like this to all zombie melee weapons:

```xml
<append xpath="/items/item[@name='meleeHandZombie01']/effect_group[@name='Base Effects']">
    <passive_effect name="DamageModifier" operation="perc_set" value="0" tags="earth,stone"/>
</append>
```

## Development

See [References/README.md](References/README.md) for more information.
