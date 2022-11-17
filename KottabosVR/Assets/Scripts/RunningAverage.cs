
using System;
using System.Linq.Expressions;


public class RunningAverage<T> : CircularQueue<T>
{
	// custom delagates to allow ref parameters
	protected delegate void IPDelegate<T1>(ref T1 param1);
	protected delegate void IPDelegate<T1, T2>(ref T1 param1, T2 param2);
	protected delegate TReturn ReturnDelegate<TReturn, T1>(T1 param1);
	protected delegate TReturn ReturnDelegate<TReturn, T1, T2>(T1 param1, T2 param2);


	protected T sum;


	protected static IPDelegate<T, T> AddIP, SubIP; // Workaround for not having access to INumber or dynamics
	protected static ReturnDelegate<T, T, uint> Div;
	protected static IPDelegate<T> SetZero;
	protected static ReturnDelegate<T, T[]> SumLoop;


	public T Average => RunningAverage<T>.Div(this.sum, this.size);


	static RunningAverage()
	{
		// define the parameters
		ParameterExpression TParam_ip = Expression.Parameter(typeof(T).MakeByRefType(), "ref T");
		ParameterExpression TParam = Expression.Parameter(typeof(T), "T");
		ParameterExpression uintParam = Expression.Parameter(typeof(uint), "uint");
		ParameterExpression arrayParam = Expression.Parameter(typeof(T[]), "array");
		ParameterExpression int32Param = Expression.Parameter(typeof(int), "int32");

		// define the label
		LabelTarget label = Expression.Label(typeof(void));


		// define the function bodies

		/* 
		 * void AddIP<T>(ref T TParam_ip, T TParam) {
		 *		TParam_ip += TParam;
		 * }
		 */
		BinaryExpression addBody = Expression.AddAssign(TParam_ip, TParam);

		/* 
		 * void SubIP<T>(ref T TParam_ip, T TParam) {
		 *		TParam_ip -= TParam;
		 * }
		 */
		BinaryExpression subBody = Expression.SubtractAssign(TParam_ip, TParam);

		/* 
		 * T Div<T>(T TParam, uint uintParam) {
		 *		return TParam / (T)uintParam;
		 * }
		 */
		BinaryExpression divBody; // TODO: Generalize to try all casts in best order
		try
		{
			divBody = Expression.Divide(TParam, uintParam);
		}
		catch (InvalidOperationException)
		{
			try
			{
				divBody = Expression.Divide(TParam, Expression.Convert(uintParam, TParam.Type));
			}
			catch (InvalidOperationException)
			{
				divBody = Expression.Divide(TParam, Expression.Convert(uintParam, typeof(float)));
			}
		}

		/* 
		 * void SetZero<T>(ref T TParam_ip) {
		 *		TParam_ip = (T)0;
		 * }
		 */
		BinaryExpression setBody = Expression.Assign(TParam_ip, Expression.Default(typeof(T)));

		/* 
		 * T SumLoop<T>(T[] arrayParam) {
		 *		TParam = (T)0;
		 *		uint int32Param = arrayParam.Length;
		 *		while (true) {
		 *			if (int32Param-- > 0) {
		 *				TParam += arrayParam[uintParam];
		 *			} else {
		 *				break;
		 *			}
		 *		}
		 *		return TParam;
		 * }
		 */
		BlockExpression sumBody = Expression.Block(new[] { arrayParam, TParam, int32Param },
			Expression.Assign(TParam, Expression.Default(typeof(T))),
			Expression.Assign(int32Param, Expression.ArrayLength(arrayParam)),
			Expression.Loop(Expression.IfThenElse(
				Expression.GreaterThan(Expression.PostDecrementAssign(int32Param), Expression.Constant(0)),
				Expression.AddAssign(TParam, Expression.ArrayIndex(arrayParam, int32Param)),
				Expression.Break(label)
				),
			label
			),
			TParam // return TParam (BlockExpressions return the final statement)
		);


		// compile and assign the functions
		RunningAverage<T>.AddIP = Expression.Lambda<IPDelegate<T, T>>(addBody, TParam_ip, TParam).Compile();
		RunningAverage<T>.SubIP = Expression.Lambda<IPDelegate<T, T>>(subBody, TParam_ip, TParam).Compile();
		RunningAverage<T>.Div = Expression.Lambda<ReturnDelegate<T, T, uint>>(divBody, TParam, uintParam).Compile();
		RunningAverage<T>.SetZero = Expression.Lambda<IPDelegate<T>>(setBody, TParam_ip).Compile();
		RunningAverage<T>.SumLoop = Expression.Lambda<ReturnDelegate<T, T[]>>(sumBody, arrayParam).Compile();
	}


	public RunningAverage(uint size) : base(size)
	{
		RunningAverage<T>.SetZero(ref this.sum);
	}

	public RunningAverage(uint size, T fill) : base(size, fill)
	{
		RunningAverage<T>.SetZero(ref this.sum);
	}


	public override T Update(T val)
	{
		RunningAverage<T>.SubIP(ref this.sum, base.Update(val));
		RunningAverage<T>.AddIP(ref this.sum, val);
		return this.Average;
	}

	public virtual void RecalculateSum()
	{
		this.sum = RunningAverage<T>.SumLoop(this.arr);
	}

	public override string ToString()
	{
		return $"{base.ToString()}\nsum: {this.sum}";
	}
}
