using UnityEngine;
using UniFramework.Event;
using UniFramework.Singleton;
using YooAsset;

public class Boot : MonoBehaviour
{
	/// <summary>
	/// 资源系统运行模式
	/// </summary>
	public EPlayMode PlayMode = EPlayMode.EditorSimulateMode;

	void Awake()
	{
		Debug.Log($"资源系统运行模式：{PlayMode}");
	}
	void Start()
	{
		// 初始化事件系统
		UniEvent.Initalize();		//wht note 不是必要的

		// 初始化单例系统
		UniSingleton.Initialize();    //wht note 不是必要的

		// 初始化资源系统
		YooAssets.Initialize();
		YooAssets.SetOperationSystemMaxTimeSlice(30);

		// wht note 上面 都要有

		// 创建补丁管理器
		UniSingleton.CreateSingleton<PatchManager>();    //wht note 不是必要的

		// 开始补丁更新流程
		PatchManager.Instance.Run(PlayMode);		//wht note 不是必要的

		//wht note 把UniFramework和BetterStreamingAssets去掉
	}
}