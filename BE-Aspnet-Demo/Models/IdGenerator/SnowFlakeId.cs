
using SnowflakeGenerator;


namespace be_aspnet_demo.models.idGenerator
{
    public class SnowFlakeId
    {
        private static readonly Settings Settings = new Settings
        {
            MachineID = 1,
            CustomEpoch = new DateTimeOffset(2024, 3, 4, 0, 0, 0, TimeSpan.Zero)
        };

        private static readonly Snowflake Snowflake = new Snowflake(Settings);

        public static long NextId()
        {
            return Snowflake.NextID();
        }
    }
}