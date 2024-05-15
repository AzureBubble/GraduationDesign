public class PlayerInfo
{
	/// <summary>
	/// 唯一主键
	/// </summary>
	public int id;

	/// <summary>
	/// 移动速度
	/// </summary>
	public float runSpeed;

	/// <summary>
	/// 跳跃速度
	/// </summary>
	public float jumpSpeed;

	/// <summary>
	/// 二段跳速度
	/// </summary>
	public float airJumpSpeed;

	/// <summary>
	/// 加速度
	/// </summary>
	public float acceleration;

	/// <summary>
	/// 减速度
	/// </summary>
	public float deceleration;

	/// <summary>
	/// 僵直时间
	/// </summary>
	public float stiffTime;

	/// <summary>
	/// 土狼时间
	/// </summary>
	public float coyoteTime;

	/// <summary>
	/// 跳跃缓冲时间
	/// </summary>
	public float jumpInputBufferTime;

	/// <summary>
	/// 悬浮移动速度
	/// </summary>
	public float floatingSpeed;

	/// <summary>
	/// 出生坐标位置
	/// </summary>
	public string bornPos;
}