/// <summary>
/// Class dedicated to creating timers.
/// </summary>
public class Timer {
    private float _timerCount;
    public float timerDuration;
    public bool timerTriggered;

    /// <summary>
    /// Creates a new timer which can be used to delay. 
    /// Must be updated manually through the use of the UpdateTimer() function.
    /// </summary>
    public Timer(float timerLength) {
        this.timerDuration = timerLength;
        this._timerCount = timerLength;
        this.timerTriggered = false;
    }

    /// <summary>
    /// Updates the timer by a specified decrement.
    /// </summary>
    public bool UpdateTimer(float decrement) {
        if (_timerCount > 0) {
            _timerCount -= decrement;
            timerTriggered = false;
        } else {
            timerTriggered = true;
        }

        return timerTriggered;
    }


    public void ResetTimer() {
        _timerCount = timerDuration;
    }

    public float GetTimerCount() {
        return _timerCount;
    }
}
