internal class BounceBetweenRailsIndexIterator
{
    private int _nextIndex = -1;
    private bool isInreasingIndex = true;
    private readonly int numberOfRails;

    public BounceBetweenRailsIndexIterator(int numberOfRails) => this.numberOfRails = numberOfRails;

    public int next
    {
        get
        {
            if (isInreasingIndex)
            {
                _nextIndex++;
            }
            else
            {
                _nextIndex--;
            }

            if (_nextIndex == numberOfRails)
            {
                isInreasingIndex = !isInreasingIndex;
                _nextIndex = numberOfRails - 2;
            }
            if (_nextIndex == -1)
            {
                isInreasingIndex = !isInreasingIndex;
                _nextIndex = 1;
            }
            return _nextIndex;
        }
    }
}