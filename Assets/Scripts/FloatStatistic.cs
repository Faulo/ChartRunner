public enum FloatStatistic {
    Jumps,
    TimePassed,
    CurrentX,
    CurrentY,
    CurrentSpeed,
    GroundedTime,
    AirborneTime,
    Rolls,
    MaximumSpeed,
    RollingTime,
    DeadTime,
}

public static class FloatStatisticExtensions {
    public static string Translate(this FloatStatistic statistic) {
        switch (statistic) {
            case FloatStatistic.Jumps:
                return "avatar.numberOfJumps";
            case FloatStatistic.TimePassed:
                return "Time.alive";
            case FloatStatistic.CurrentX:
                return "transform.position.x";
            case FloatStatistic.CurrentY:
                return "transform.position.y";
            case FloatStatistic.CurrentSpeed:
                return "rigidbody.velocity.magnitude";
            case FloatStatistic.GroundedTime:
                return "Time.grounded";
            case FloatStatistic.AirborneTime:
                return "Time.airborne";
            case FloatStatistic.RollingTime:
                return "Time.rolling";
            case FloatStatistic.DeadTime:
                return "Time.dead";
            case FloatStatistic.Rolls:
                return "avatar.numberOfRolls";
            case FloatStatistic.MaximumSpeed:
                return "Math.Max(rigidbody.velocity.magnitude)";
            default:
                return statistic.ToString();
        }
    }
}