using Leopotam.Ecs;

namespace Extensions
{
    public static class FilterExtensions
    {
        public static bool TryGet1<T1>(this EcsFilter<T1> filter, out EcsComponentRef<T1> component)
            where T1 : struct
        {
            var enumerator = filter.GetEnumerator();
            if (enumerator.MoveNext())
            {
                component = filter.Get1Ref(enumerator.Current);
                return true;
            }

            component = default;
            return false;
        }

        public static bool TryGet1<T1, T2>(this EcsFilter<T1, T2> filter, out EcsComponentRef<T1> component)
            where T1 : struct where T2 : struct
        {
            var enumerator = filter.GetEnumerator();
            if (enumerator.MoveNext())
            {
                component = filter.Get1Ref(enumerator.Current);
                return true;
            }

            component = default;
            return false;
        }

        public static bool TryGet2<T1, T2>(this EcsFilter<T1, T2> filter, out EcsComponentRef<T2> component)
            where T1 : struct where T2 : struct
        {
            var enumerator = filter.GetEnumerator();
            if (enumerator.MoveNext())
            {
                component = filter.Get2Ref(enumerator.Current);
                return true;
            }

            component = default;
            return false;
        }
    }
}