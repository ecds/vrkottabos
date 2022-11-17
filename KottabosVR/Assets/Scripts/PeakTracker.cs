public class PeakTracker
{
	protected float resetThreshold;
	protected float resetValue;
	protected float currentPeak;

	public float CurrentPeak => this.currentPeak;


	public PeakTracker(float resetThreshold=0, float resetValue=0)
	{
		this.resetThreshold = resetThreshold;
		this.resetValue = resetValue;
		this.currentPeak = resetValue;
	}


	public float Update(float val)
	{
		if (val < this.resetThreshold)
		{
			this.currentPeak = this.resetValue;
		}
		else if (val > this.currentPeak)
		{
			this.currentPeak = val;
		}
		return this.currentPeak;
	}

	public void Reset()
	{
		this.currentPeak = this.resetValue;
	}

	public static bool operator >(PeakTracker peak, float other)
	{
		return peak.currentPeak > other;
	}
	
	public static bool operator <(PeakTracker peak, float other)
	{
		return peak.currentPeak < other;
	}

	public static bool operator >=(PeakTracker peak, float other)
	{
		return peak.currentPeak >= other;
	}

	public static bool operator <=(PeakTracker peak, float other)
	{
		return peak.currentPeak <= other;
	}

	public static bool operator >(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak > other.currentPeak;
	}

	public static bool operator <(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak < other.currentPeak;
	}

	public static bool operator >=(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak >= other.currentPeak;
	}

	public static bool operator <=(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak <= other.currentPeak;
	}

	public static bool operator ==(PeakTracker peak, float other)
	{
		return peak.currentPeak == other;
	}

	public static bool operator !=(PeakTracker peak, float other)
	{
		return peak.currentPeak != other;
	}

	public static bool operator ==(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak == other.currentPeak;
	}

	public static bool operator !=(PeakTracker peak, PeakTracker other)
	{
		return peak.currentPeak != other.currentPeak;
	}

	public override bool Equals(object other)
	{
		return this.currentPeak > (float)other;
	}

	public static explicit operator float(PeakTracker peak) => peak.currentPeak;

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}