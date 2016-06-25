#Emoticon

Properties:

Health, Armor, MovementSpeed, Location (x, y)

Constructors:
protected Emoticon(Location(x, y))

---------------------------------------------------------
#BadEmoticon : Emoticon

Properties: 

Damage, AttackSpeed

Constructors:
protected Emoticon(Location(x, y)) : base(Location(x, y))

---------------------------------------------------------
#GoodEmoticon : Emoticon

Properties: 

Reward

Constructors:
protected Emoticon(Location(x, y)) : base(Location(x, y))

---------------------------------------------------------
#SpecificEmoticon : BadEmoticon

Constants:

DefaultHealth, DefaultArmor, DefaultMovementSpeed, DefaultDamage, DefaultAttackSpeed

Constructors:
protected Emoticon(Location(x, y)) : base(Location(x, y))

The default values should be set in the constructor!
---------------------------------------------------------
#SpecificEmoticon : GoodEmoticon

Constants:

DefaultHealth, DefaultArmor, DefaultMovementSpeed, DefaultReward

Constructors:
protected Emoticon(Location(x, y)) : base(Location(x, y))

The default values should be set in the constructor!
