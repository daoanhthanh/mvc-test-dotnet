// namespace be_aspnet_demo.utils.monads;
//
// public class Try<T>
// {
//     public Either<Exception, T> Result { get; set; }
//     public Try(Func<Either<Exception, T>> @try)
//     {
//         try
//         {
//             Result = @try();
//         }
//         catch (Exception e)
//         {
//             Result = e;
//         }
//     }
//         
//     public Try<T1> Select<T1> (Func<T,T1> func)
//     {
//         return  Result.Match(
//             Left: e => new Try<T1>(() => e),
//             Right: result => new Try<T1>(()=>func(result))); 
//     }
//         
// }