extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_Terrain();
	RegisterModule_Terrain();

	void RegisterModule_TerrainPhysics();
	RegisterModule_TerrainPhysics();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UnityConnect();
	RegisterModule_UnityConnect();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_ImageConversion();
	RegisterModule_ImageConversion();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_XR();
	RegisterModule_XR();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

	void RegisterModule_UnityAnalytics();
	RegisterModule_UnityAnalytics();

	void RegisterModule_GameCenter();
	RegisterModule_GameCenter();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_VR();
	RegisterModule_VR();

	void RegisterModule_TLS();
	RegisterModule_TLS();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

namespace ObjectProduceTestTypes { class Derived; } 
namespace ObjectProduceTestTypes { class SubDerived; } 
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class Animation; 
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioSource; 
class AudioFilter; 
class AudioChorusFilter; 
class AudioDistortionFilter; 
class AudioEchoFilter; 
class AudioHighPassFilter; 
class AudioLowPassFilter; 
class AudioReverbFilter; 
class AudioReverbZone; 
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace Unity { class Cloth; } 
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class BoxCollider2D; template <> void RegisterUnityClass<BoxCollider2D>(const char*);
class CapsuleCollider2D; template <> void RegisterUnityClass<CapsuleCollider2D>(const char*);
class CircleCollider2D; template <> void RegisterUnityClass<CircleCollider2D>(const char*);
class CompositeCollider2D; 
class EdgeCollider2D; template <> void RegisterUnityClass<EdgeCollider2D>(const char*);
class PolygonCollider2D; 
class TilemapCollider2D; 
class ConstantForce; 
class Effector2D; 
class AreaEffector2D; 
class BuoyancyEffector2D; 
class PlatformEffector2D; 
class PointEffector2D; 
class SurfaceEffector2D; 
class FlareLayer; 
class GUIElement; template <> void RegisterUnityClass<GUIElement>(const char*);
namespace TextRenderingPrivate { class GUIText; } 
class GUITexture; 
class GUILayer; template <> void RegisterUnityClass<GUILayer>(const char*);
class GridLayout; 
class Grid; 
class Tilemap; 
class Halo; 
class HaloLayer; 
class IConstraint; 
class AimConstraint; 
class LookAtConstraint; 
class ParentConstraint; 
class PositionConstraint; 
class RotationConstraint; 
class ScaleConstraint; 
class Joint2D; 
class AnchoredJoint2D; 
class DistanceJoint2D; 
class FixedJoint2D; 
class FrictionJoint2D; 
class HingeJoint2D; 
class SliderJoint2D; 
class SpringJoint2D; 
class WheelJoint2D; 
class RelativeJoint2D; 
class TargetJoint2D; 
class LensFlare; 
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightProbeGroup; 
class LightProbeProxyVolume; 
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class NavMeshAgent; 
class NavMeshObstacle; 
class OffMeshLink; 
class ParticleSystemForceField; 
class PhysicsUpdateBehaviour2D; 
class ConstantForce2D; 
class PlayableDirector; 
class Projector; 
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Skybox; 
class SortingGroup; 
class StreamingController; 
class Terrain; template <> void RegisterUnityClass<Terrain>(const char*);
class VideoPlayer; 
class VisualEffect; 
class WindZone; 
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class BoxCollider; template <> void RegisterUnityClass<BoxCollider>(const char*);
class CapsuleCollider; template <> void RegisterUnityClass<CapsuleCollider>(const char*);
class CharacterController; template <> void RegisterUnityClass<CharacterController>(const char*);
class MeshCollider; template <> void RegisterUnityClass<MeshCollider>(const char*);
class SphereCollider; template <> void RegisterUnityClass<SphereCollider>(const char*);
class TerrainCollider; template <> void RegisterUnityClass<TerrainCollider>(const char*);
class WheelCollider; 
class FakeComponent; 
namespace Unity { class Joint; } 
namespace Unity { class CharacterJoint; } 
namespace Unity { class ConfigurableJoint; } 
namespace Unity { class FixedJoint; } 
namespace Unity { class HingeJoint; } 
namespace Unity { class SpringJoint; } 
class LODGroup; 
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class OcclusionArea; 
class OcclusionPortal; 
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class BillboardRenderer; 
class LineRenderer; template <> void RegisterUnityClass<LineRenderer>(const char*);
class RendererFake; 
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class SkinnedMeshRenderer; template <> void RegisterUnityClass<SkinnedMeshRenderer>(const char*);
class SpriteMask; 
class SpriteRenderer; 
class SpriteShapeRenderer; 
class TilemapRenderer; 
class TrailRenderer; 
class VFXRenderer; 
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRenderingPrivate { class TextMesh; } 
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class Tree; 
class WorldAnchor; 
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class AssetBundle; 
class AssetBundleManifest; 
class ScriptedImporter; 
class AudioMixer; 
class AudioMixerController; 
class AudioMixerGroup; 
class AudioMixerGroupController; 
class AudioMixerSnapshot; 
class AudioMixerSnapshotController; 
class Avatar; 
class AvatarMask; 
class BillboardAsset; 
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Flare; 
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
class GameObjectRecorder; 
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LocalizationAsset; 
class Material; template <> void RegisterUnityClass<Material>(const char*);
class ProceduralMaterial; 
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class Motion; 
class AnimationClip; 
class PreviewAnimationClip; 
class NavMeshData; 
class OcclusionCullingData; 
class PhysicMaterial; 
class PhysicsMaterial2D; 
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AnimatorController; 
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class SampleClip; 
class AudioClip; 
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderVariantCollection; 
class SpeedTreeWindAsset; 
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SubstanceArchive; 
class TerrainData; template <> void RegisterUnityClass<TerrainData>(const char*);
class TerrainLayer; 
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class CGProgram; template <> void RegisterUnityClass<CGProgram>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class BaseVideoTexture; 
class MovieTexture; 
class WebCamTexture; 
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class ProceduralTexture; 
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class CustomRenderTexture; 
class SparseTexture; 
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class VideoClip; 
class VisualEffectObject; 
class VisualEffectAsset; 
class VisualEffectSubgraph; 
class VisualEffectSubgraphBlock; 
class VisualEffectSubgraphOperator; 
class VisualEffectResource; 
class EmptyObject; 
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class NavMeshProjectSettings; 
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class ScriptMapper; template <> void RegisterUnityClass<ScriptMapper>(const char*);
class StreamingManager; 
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class UnityConnectSettings; template <> void RegisterUnityClass<UnityConnectSettings>(const char*);
class VFXManager; 
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class NavMeshSettings; 
class OcclusionCullingSettings; 
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class NativeObjectType; 
class PropertyModificationsTargetTestObject; 
class SerializableManagedHost; 
class SerializableManagedRefTestClass; 
namespace ObjectProduceTestTypes { class SiblingDerived; } 
class TestObjectVectorPairStringBool; 
class TestObjectWithSerializedAnimationCurve; 
class TestObjectWithSerializedArray; 
class TestObjectWithSerializedMapStringBool; 
class TestObjectWithSerializedMapStringNonAlignedStruct; 
class TestObjectWithSpecialLayoutOne; 
class TestObjectWithSpecialLayoutTwo; 

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 85 non stripped classes
	//0. Camera
	RegisterUnityClass<Camera>("Core");
	//1. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//2. Unity::Component
	RegisterUnityClass<Unity::Component>("Core");
	//3. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//4. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//5. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//6. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//7. GameManager
	RegisterUnityClass<GameManager>("Core");
	//8. LineRenderer
	RegisterUnityClass<LineRenderer>("Core");
	//9. Renderer
	RegisterUnityClass<Renderer>("Core");
	//10. Shader
	RegisterUnityClass<Shader>("Core");
	//11. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//12. Material
	RegisterUnityClass<Material>("Core");
	//13. Light
	RegisterUnityClass<Light>("Core");
	//14. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//15. SkinnedMeshRenderer
	RegisterUnityClass<SkinnedMeshRenderer>("Core");
	//16. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//17. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//18. Mesh
	RegisterUnityClass<Mesh>("Core");
	//19. Texture
	RegisterUnityClass<Texture>("Core");
	//20. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//21. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//22. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//23. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//24. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//25. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//26. GUIElement
	RegisterUnityClass<GUIElement>("Core");
	//27. GUILayer
	RegisterUnityClass<GUILayer>("Core");
	//28. GameObject
	RegisterUnityClass<GameObject>("Core");
	//29. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//30. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//31. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//32. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//33. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//34. UI::RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//35. Transform
	RegisterUnityClass<Transform>("Core");
	//36. Sprite
	RegisterUnityClass<Sprite>("Core");
	//37. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//38. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//39. Collider
	RegisterUnityClass<Collider>("Physics");
	//40. CharacterController
	RegisterUnityClass<CharacterController>("Physics");
	//41. MeshCollider
	RegisterUnityClass<MeshCollider>("Physics");
	//42. CapsuleCollider
	RegisterUnityClass<CapsuleCollider>("Physics");
	//43. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//44. SphereCollider
	RegisterUnityClass<SphereCollider>("Physics");
	//45. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//46. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//47. CircleCollider2D
	RegisterUnityClass<CircleCollider2D>("Physics2D");
	//48. CapsuleCollider2D
	RegisterUnityClass<CapsuleCollider2D>("Physics2D");
	//49. EdgeCollider2D
	RegisterUnityClass<EdgeCollider2D>("Physics2D");
	//50. BoxCollider2D
	RegisterUnityClass<BoxCollider2D>("Physics2D");
	//51. TerrainCollider
	RegisterUnityClass<TerrainCollider>("TerrainPhysics");
	//52. Terrain
	RegisterUnityClass<Terrain>("Terrain");
	//53. TerrainData
	RegisterUnityClass<TerrainData>("Terrain");
	//54. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//55. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//56. TextRendering::Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//57. UI::CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//58. UI::CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");
	//59. UI::Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//60. Animator
	RegisterUnityClass<Animator>("Animation");
	//61. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//62. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//63. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//64. UnityConnectSettings
	RegisterUnityClass<UnityConnectSettings>("UnityConnect");
	//65. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//66. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//67. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//68. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//69. InputManager
	RegisterUnityClass<InputManager>("Core");
	//70. TagManager
	RegisterUnityClass<TagManager>("Core");
	//71. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//72. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//73. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//74. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//75. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//76. ScriptMapper
	RegisterUnityClass<ScriptMapper>("Core");
	//77. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//78. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//79. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//80. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//81. CGProgram
	RegisterUnityClass<CGProgram>("Core");
	//82. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//83. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//84. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");

}