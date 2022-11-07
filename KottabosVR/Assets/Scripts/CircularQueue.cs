using System;
using System.Collections;
using System.Collections.Generic;


public class CircularQueue<T> : IEnumerable<T>, IReadOnlyCollection<T>, ICollection
{
	protected readonly uint size;
	protected readonly T[] arr;

	protected uint index;
	protected T cache;


	public int Count => (int)this.size;

	public bool IsSynchronized => this.arr.IsSynchronized;

	public object SyncRoot => this.arr.SyncRoot;

	public T Cache => this.cache;


	public CircularQueue(uint size)
	{
		this.size = size;
		this.arr = new T[size];
		this.index = 0;
	}

	public CircularQueue(uint size, T fill) : this(size)
	{
		for(nuint i = 0; i < size; i++)
		{
			this.arr[i] = fill;
		}
	}

	public virtual T Update(T val)
	{
		this.cache = this.arr[this.index];
		this.arr[this.index] = val;
		if (++this.index >= this.size)
		{
			this.index = 0;
		}
		return this.cache;
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return (IEnumerator<T>)this.arr.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.arr.GetEnumerator();
	}

	public void CopyTo(System.Array array, int index)
	{
		this.arr.CopyTo(array, index);
	}

	public override string ToString()
	{
		return $"{this.GetType().Name}: [{String.Join(", ", this.arr)}]";
	}
}
