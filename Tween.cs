using System;
using System.Threading;

namespace TweenySharp
{
    public class Tween<T>
    {
        private T currentValue;
        private float currentProgress;
        
        public enum DirectionType
        {
            Forward = 1,
            Backward = -1
        }

        public DirectionType Direction { get; private set; }
        public Easing.IEase Ease { get; private set; }
        public T Start { get; private set; }
        public T End { get; private set; }

        public event Action<T> OnStep;
        public event Action<T> OnSeek;

        public long Duration { get; private set; }

        public Tween()
        {
            if (!Easing.IsNumeric<T>())
                throw new Exception("Value must be an integer type!");
            Direction = DirectionType.Forward;
        }

        public Tween(T from, T end, Easing.EaseType easeType, DirectionType direction = DirectionType.Forward)
        {
            if (!Easing.IsNumeric<T>())
                throw new Exception("Tween: Value must be an integer type!");
            Start = from;
            End = end;
            Direction = direction;
            Ease = GetEaseFromEnum(easeType);
        }

        public Tween<T> From(T from)
        {
            Start = from;
            return this;
        }

        public Tween<T> To(T to)
        {
            End = to;
            return this;
        }

        public Tween<T> During<T1>(T1 duration)
        {
            if (!Easing.IsSigned<T1>())
                throw new Exception("Tween.During: Value must be signed and not real!");
            Duration = (long)Convert.ChangeType(duration, typeof(long));
            return this;
        }

        public Tween<T> SetOnSeek(Action<T> callback)
        {
            OnSeek += callback;
            return this;
        }

        public Tween<T> SetOnStep(Action<T> callback)
        {
            OnStep += callback;
            return this;
        }

        public T Seek(float progress, bool suppressCallback)
        {
            currentProgress = Clip(progress, 0f, 1f);
            currentValue = Clip(Convert.ChangeType(Ease.Run(currentProgress, Start, End), typeof(T)), Start, End);
            if(!suppressCallback)
                OnSeek?.Invoke(currentValue);
            return currentValue;
        }
        
        
        public T Step(float progress, bool suppressCallback)
        {
            progress *= (int)Direction;
            Seek(currentProgress + progress, true);
            if (!suppressCallback)
                OnStep?.Invoke(currentValue);
            return currentValue;
        }

        public T Step(int progress, bool suppressCallback)
        {
            return Step((float)progress / Duration, suppressCallback);
        }

        public Tween<T> Via(Easing.EaseType type)
        {
            Ease = GetEaseFromEnum(type);
            return this;
        }

        public Tween<T> Via(Easing.IEase ease)
        {
            Ease = ease;
            return this;
        }

        public Tween<T> Via(string name)
        {
            var fromEnum = Enum.Parse<Easing.EaseType>(name);
            return Via(fromEnum);
        }

        public Tween<T> Forward()
        {
            Direction = DirectionType.Forward;
            return this;
        }

        public Tween<T> Backward()
        {
            Direction = DirectionType.Backward;
            return this;
        }

        public static Easing.IEase GetEaseFromEnum(Easing.EaseType type)
        { 
            return type switch
            {
                Easing.EaseType.Default => new Easing.Default(),
                Easing.EaseType.Linear => new Easing.Linear(),
                Easing.EaseType.Stepped => new Easing.Stepped(),
                Easing.EaseType.QuadraticIn => new Easing.QuadraticIn(),
                Easing.EaseType.QuadraticOut => new Easing.QuadraticOut(),
                Easing.EaseType.QuadraticInOut => new Easing.QuadraticInOut(),
                Easing.EaseType.CubicIn => new Easing.CubicIn(),
                Easing.EaseType.CubicOut => new Easing.CubicOut(),
                Easing.EaseType.CubicInOut => new Easing.CubicInOut(),
                Easing.EaseType.QuarticIn => new Easing.QuarticIn(),
                Easing.EaseType.QuarticOut => new Easing.QuarticOut(),
                Easing.EaseType.QuarticInOut => new Easing.QuarticInOut(),
                Easing.EaseType.QuinticIn => new Easing.QuinticIn(),
                Easing.EaseType.QuinticOut => new Easing.QuinticOut(),
                Easing.EaseType.QuinticInOut => new Easing.QuinticInOut(),
                Easing.EaseType.SinusoidalIn => new Easing.SinusoidalIn(),
                Easing.EaseType.SinusoidalOut => new Easing.SinusoidalOut(),
                Easing.EaseType.SinusoidalInOut => new Easing.SinusoidalInOut(),
                Easing.EaseType.ExponentialIn => new Easing.ExponentialIn(),
                Easing.EaseType.ExponentialOut => new Easing.ExponentialOut(),
                Easing.EaseType.ExponentialInOut => new Easing.ExponentialInOut(),
                Easing.EaseType.CircularIn => new Easing.CircularIn(),
                Easing.EaseType.CircularOut => new Easing.CircularOut(),
                Easing.EaseType.CircularInOut => new Easing.CircularInOut(),
                Easing.EaseType.BounceIn => new Easing.BounceIn(),
                Easing.EaseType.BounceOut => new Easing.BounceOut(),
                Easing.EaseType.BounceInOut => new Easing.BounceInOut(),
                Easing.EaseType.ElasticIn => new Easing.ElasticIn(),
                Easing.EaseType.ElasticOut => new Easing.ElasticOut(),
                Easing.EaseType.ElasticInOut => new Easing.ElasticInOut(),
                Easing.EaseType.BackIn => new Easing.BackIn(),
                Easing.EaseType.BackOut => new Easing.BackOut(),
                Easing.EaseType.BackInOut => new Easing.BackInOut(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        public static T2 Clip<T2>(T2 n, T2 lower, T2 upper)
        {
            if (!Easing.IsNumeric<T2>())
                throw new Exception("Tween.Clip: Value must be an integer!"); 
            return Math.Max((dynamic)lower, Math.Min((dynamic)n, (dynamic)upper));
        }
    }
}
