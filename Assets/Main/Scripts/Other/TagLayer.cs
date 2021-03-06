public enum Tag { Untagged, Respawn, Finish, EditorOnly, MainCamera, Player, GameController, Diamond, Bot, Coin, Water, Horse }

public partial class Lyr {
	public const int Default = 0;
	public const int TransparentFX = 1;
	public const int IgnoreRaycast = 2;
	public const int Water = 4;
	public const int UI = 5;
	public const int Animal = 20;
}

public class LM {
	public const int Default = 1;
	public const int TransparentFX = 2;
	public const int IgnoreRaycast = 4;
	public const int Water = 16;
	public const int UI = 32;
	public const int Animal = 1048576;
}