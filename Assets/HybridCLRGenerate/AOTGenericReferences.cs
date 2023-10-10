using System.Collections.Generic;
public class AOTGenericReferences : UnityEngine.MonoBehaviour
{

	// {{ AOT assemblies
	public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
	{
		"System.Core.dll",
		"System.dll",
		"Unity.Addressables.dll",
		"Unity.ResourceManager.dll",
		"UnityEngine.AnimationModule.dll",
		"UnityEngine.CoreModule.dll",
		"UnityEngine.JSONSerializeModule.dll",
		"mscorlib.dll",
	};
	// }}

	// {{ constraint implement type
	// }} 

	// {{ AOT generic types
	// DelegateList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// DelegateList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// DelegateList<float>
	// System.Action<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Action<UnityEngine.Color>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,object>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// System.Action<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Action<byte,object,object>
	// System.Action<byte,object>
	// System.Action<float>
	// System.Action<int>
	// System.Action<object>
	// System.Collections.Generic.ArraySortHelper<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.Color>
	// System.Collections.Generic.ArraySortHelper<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ArraySortHelper<int>
	// System.Collections.Generic.ArraySortHelper<object>
	// System.Collections.Generic.Comparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.Comparer<UnityEngine.Color>
	// System.Collections.Generic.Comparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.Comparer<float>
	// System.Collections.Generic.Comparer<int>
	// System.Collections.Generic.Comparer<object>
	// System.Collections.Generic.Dictionary.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.Enumerator<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.KeyCollection<int,long>
	// System.Collections.Generic.Dictionary.KeyCollection<int,object>
	// System.Collections.Generic.Dictionary.KeyCollection<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.KeyCollection<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection.Enumerator<object,object>
	// System.Collections.Generic.Dictionary.ValueCollection<int,long>
	// System.Collections.Generic.Dictionary.ValueCollection<int,object>
	// System.Collections.Generic.Dictionary.ValueCollection<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary.ValueCollection<object,object>
	// System.Collections.Generic.Dictionary<int,long>
	// System.Collections.Generic.Dictionary<int,object>
	// System.Collections.Generic.Dictionary<object,UnityEngine.Vector3>
	// System.Collections.Generic.Dictionary<object,object>
	// System.Collections.Generic.EqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.EqualityComparer<int>
	// System.Collections.Generic.EqualityComparer<long>
	// System.Collections.Generic.EqualityComparer<object>
	// System.Collections.Generic.HashSet.Enumerator<object>
	// System.Collections.Generic.HashSet<object>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,UnityEngine.Vector3>>
	// System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ICollection<UnityEngine.Color>
	// System.Collections.Generic.ICollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ICollection<int>
	// System.Collections.Generic.ICollection<object>
	// System.Collections.Generic.IComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IComparer<UnityEngine.Color>
	// System.Collections.Generic.IComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IComparer<float>
	// System.Collections.Generic.IComparer<int>
	// System.Collections.Generic.IComparer<object>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerable<UnityEngine.Color>
	// System.Collections.Generic.IEnumerable<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerable<int>
	// System.Collections.Generic.IEnumerable<object>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,long>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int,object>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,UnityEngine.Vector3>>
	// System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IEnumerator<UnityEngine.Color>
	// System.Collections.Generic.IEnumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IEnumerator<int>
	// System.Collections.Generic.IEnumerator<object>
	// System.Collections.Generic.IEqualityComparer<int>
	// System.Collections.Generic.IEqualityComparer<object>
	// System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.IList<UnityEngine.Color>
	// System.Collections.Generic.IList<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.IList<int>
	// System.Collections.Generic.IList<object>
	// System.Collections.Generic.KeyValuePair<int,long>
	// System.Collections.Generic.KeyValuePair<int,object>
	// System.Collections.Generic.KeyValuePair<object,UnityEngine.Vector3>
	// System.Collections.Generic.KeyValuePair<object,object>
	// System.Collections.Generic.LinkedList.Enumerator<object>
	// System.Collections.Generic.LinkedList<object>
	// System.Collections.Generic.LinkedListNode<object>
	// System.Collections.Generic.List.Enumerator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List.Enumerator<UnityEngine.Color>
	// System.Collections.Generic.List.Enumerator<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List.Enumerator<int>
	// System.Collections.Generic.List.Enumerator<object>
	// System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.List<UnityEngine.Color>
	// System.Collections.Generic.List<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.List<int>
	// System.Collections.Generic.List<object>
	// System.Collections.Generic.ObjectComparer<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.Generic.ObjectComparer<UnityEngine.Color>
	// System.Collections.Generic.ObjectComparer<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.Generic.ObjectComparer<float>
	// System.Collections.Generic.ObjectComparer<int>
	// System.Collections.Generic.ObjectComparer<object>
	// System.Collections.Generic.ObjectEqualityComparer<UnityEngine.Vector3>
	// System.Collections.Generic.ObjectEqualityComparer<int>
	// System.Collections.Generic.ObjectEqualityComparer<long>
	// System.Collections.Generic.ObjectEqualityComparer<object>
	// System.Collections.ObjectModel.ReadOnlyCollection<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.Color>
	// System.Collections.ObjectModel.ReadOnlyCollection<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Collections.ObjectModel.ReadOnlyCollection<int>
	// System.Collections.ObjectModel.ReadOnlyCollection<object>
	// System.Comparison<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Comparison<UnityEngine.Color>
	// System.Comparison<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Comparison<int>
	// System.Comparison<object>
	// System.Func<System.Collections.Generic.KeyValuePair<object,object>,byte>
	// System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Func<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>
	// System.Func<byte>
	// System.Func<object,byte>
	// System.Func<object,float>
	// System.Func<object,int>
	// System.Func<object,object>
	// System.Func<object>
	// System.Linq.Buffer<object>
	// System.Linq.Enumerable.<ReverseIterator>d__79<object>
	// System.Linq.Enumerable.<SelectManyIterator>d__17<object,object>
	// System.Linq.Enumerable.<UnionIterator>d__71<object>
	// System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Linq.Enumerable.Iterator<object>
	// System.Linq.Enumerable.WhereArrayIterator<object>
	// System.Linq.Enumerable.WhereEnumerableIterator<object>
	// System.Linq.Enumerable.WhereListIterator<object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectArrayIterator<object,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectEnumerableIterator<object,object>
	// System.Linq.Enumerable.WhereSelectListIterator<System.Collections.Generic.KeyValuePair<object,object>,object>
	// System.Linq.Enumerable.WhereSelectListIterator<object,object>
	// System.Linq.EnumerableSorter<object,float>
	// System.Linq.EnumerableSorter<object,int>
	// System.Linq.EnumerableSorter<object>
	// System.Linq.GroupedEnumerable<object,int,object>
	// System.Linq.IOrderedEnumerable<object>
	// System.Linq.IdentityFunction.<>c<object>
	// System.Linq.IdentityFunction<object>
	// System.Linq.Lookup.<GetEnumerator>d__12<int,object>
	// System.Linq.Lookup.Grouping.<GetEnumerator>d__7<int,object>
	// System.Linq.Lookup.Grouping<int,object>
	// System.Linq.Lookup<int,object>
	// System.Linq.OrderedEnumerable.<GetEnumerator>d__1<object>
	// System.Linq.OrderedEnumerable<object,float>
	// System.Linq.OrderedEnumerable<object,int>
	// System.Linq.OrderedEnumerable<object>
	// System.Linq.Set<object>
	// System.Nullable<UnityEngine.Color>
	// System.Nullable<int>
	// System.Predicate<System.Collections.Generic.KeyValuePair<object,object>>
	// System.Predicate<UnityEngine.Color>
	// System.Predicate<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>
	// System.Predicate<int>
	// System.Predicate<object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.CreateValueCallback<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable.Enumerator<object,object>
	// System.Runtime.CompilerServices.ConditionalWeakTable<object,object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable.ConfiguredTaskAwaiter<object>
	// System.Runtime.CompilerServices.ConfiguredTaskAwaitable<object>
	// System.Runtime.CompilerServices.TaskAwaiter<object>
	// System.Threading.Tasks.Task<object>
	// System.Threading.Tasks.TaskCompletionSource<object>
	// System.Threading.Tasks.TaskFactory<object>
	// UnityEngine.AddressableAssets.AddressablesImpl.<>c__DisplayClass79_0<object>
	// UnityEngine.Events.InvokableCall<float>
	// UnityEngine.Events.UnityAction<float>
	// UnityEngine.Events.UnityEvent<float>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass60_0<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase.<>c__DisplayClass61_0<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase<object>
	// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>
	// UnityEngine.ResourceManagement.ChainOperationTypelessDepedency<object>
	// UnityEngine.ResourceManagement.ResourceManager.CompletedOperation<object>
	// UnityEngine.ResourceManagement.Util.GlobalLinkedListNodeCache<object>
	// UnityEngine.ResourceManagement.Util.LinkedListNodeCache<object>
	// }}

	public void RefMethods()
	{
		// object System.Activator.CreateInstance<object>()
		// bool System.Linq.Enumerable.All<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>)
		// bool System.Linq.Enumerable.Any<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// int System.Linq.Enumerable.Count<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.KeyValuePair<object,object> System.Linq.Enumerable.First<System.Collections.Generic.KeyValuePair<object,object>>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>)
		// object System.Linq.Enumerable.First<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>)
		// object System.Linq.Enumerable.FirstOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<System.Linq.IGrouping<int,object>> System.Linq.Enumerable.GroupBy<object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,int>)
		// object System.Linq.Enumerable.Last<object>(System.Collections.Generic.IEnumerable<object>)
		// object System.Linq.Enumerable.Last<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// object System.Linq.Enumerable.LastOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.OrderBy<object,float>(System.Collections.Generic.IEnumerable<object>,System.Func<object,float>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.OrderBy<object,int>(System.Collections.Generic.IEnumerable<object>,System.Func<object,int>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Reverse<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.ReverseIterator<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<System.Collections.Generic.KeyValuePair<object,object>,object>(System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<object,object>>,System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Select<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectMany<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.SelectManyIterator<object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,System.Collections.Generic.IEnumerable<object>>)
		// bool System.Linq.Enumerable.SequenceEqual<int>(System.Collections.Generic.IEnumerable<int>,System.Collections.Generic.IEnumerable<int>)
		// bool System.Linq.Enumerable.SequenceEqual<int>(System.Collections.Generic.IEnumerable<int>,System.Collections.Generic.IEnumerable<int>,System.Collections.Generic.IEqualityComparer<int>)
		// bool System.Linq.Enumerable.SequenceEqual<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// bool System.Linq.Enumerable.SequenceEqual<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// object System.Linq.Enumerable.Single<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// object System.Linq.Enumerable.SingleOrDefault<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.ThenBy<object,int>(System.Linq.IOrderedEnumerable<object>,System.Func<object,int>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.Enumerable.ThenBy<object,object>(System.Linq.IOrderedEnumerable<object>,System.Func<object,object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<object,object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>,System.Func<object,object>)
		// System.Collections.Generic.Dictionary<object,object> System.Linq.Enumerable.ToDictionary<object,object,object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,object>,System.Func<object,object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.List<object> System.Linq.Enumerable.ToList<object>(System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Union<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.UnionIterator<object>(System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEnumerable<object>,System.Collections.Generic.IEqualityComparer<object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Where<object>(System.Collections.Generic.IEnumerable<object>,System.Func<object,bool>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<System.Collections.Generic.KeyValuePair<object,object>>.Select<object>(System.Func<System.Collections.Generic.KeyValuePair<object,object>,object>)
		// System.Collections.Generic.IEnumerable<object> System.Linq.Enumerable.Iterator<object>.Select<object>(System.Func<object,object>)
		// System.Linq.IOrderedEnumerable<object> System.Linq.IOrderedEnumerable<object>.CreateOrderedEnumerable<int>(System.Func<object,int>,System.Collections.Generic.IComparer<int>,bool)
		// System.Linq.IOrderedEnumerable<object> System.Linq.IOrderedEnumerable<object>.CreateOrderedEnumerable<object>(System.Func<object,object>,System.Collections.Generic.IComparer<object>,bool)
		// object& System.Runtime.CompilerServices.Unsafe.As<object,object>(object&)
		// System.Void* System.Runtime.CompilerServices.Unsafe.AsPointer<object>(object&)
		// object System.Threading.Interlocked.CompareExchange<object>(object&,object,object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.Addressables.LoadAssetAsync<object>(object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetAsync<object>(object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.LoadAssetWithChain<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,object)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AddressablesImpl.TrackHandle<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.AddressableAssets.AssetReference.LoadAssetAsync<object>()
		// object[] UnityEngine.Animator.ConvertStateMachineBehaviour<object>(UnityEngine.ScriptableObject[])
		// object[] UnityEngine.Animator.GetBehaviours<object>()
		// object UnityEngine.Component.GetComponent<object>()
		// object UnityEngine.Component.GetComponentInParent<object>()
		// object[] UnityEngine.Component.GetComponents<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>()
		// object[] UnityEngine.Component.GetComponentsInChildren<object>(bool)
		// object UnityEngine.GameObject.AddComponent<object>()
		// object UnityEngine.GameObject.GetComponent<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>()
		// object UnityEngine.GameObject.GetComponentInChildren<object>(bool)
		// object[] UnityEngine.GameObject.GetComponents<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>()
		// object[] UnityEngine.GameObject.GetComponentsInChildren<object>(bool)
		// object UnityEngine.JsonUtility.FromJson<object>(string)
		// object UnityEngine.Object.FindObjectOfType<object>()
		// object UnityEngine.Object.Instantiate<object>(object)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Transform,bool)
		// object UnityEngine.Object.Instantiate<object>(object,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Transform)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle.Convert<object>()
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateChainOperation<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,System.Func<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object>>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateCompletedOperationInternal<object>(object,bool,System.Exception,bool)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.CreateCompletedOperationWithException<object>(object,System.Exception)
		// object UnityEngine.ResourceManagement.ResourceManager.CreateOperation<object>(System.Type,int,UnityEngine.ResourceManagement.Util.IOperationCacheKey,System.Action<UnityEngine.ResourceManagement.AsyncOperations.IAsyncOperation>)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.ProvideResource<object>(UnityEngine.ResourceManagement.ResourceLocations.IResourceLocation)
		// UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<object> UnityEngine.ResourceManagement.ResourceManager.StartOperation<object>(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationBase<object>,UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle)
		// object UnityEngine.ScriptableObject.CreateInstance<object>()
		// string string.Join<object>(string,System.Collections.Generic.IEnumerable<object>)
		// string string.JoinCore<object>(System.Char*,int,System.Collections.Generic.IEnumerable<object>)
	}
}