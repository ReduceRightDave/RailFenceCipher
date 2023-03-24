internal class StringWithCharIterator
{ 
    private readonly string str;
    private int index = 0;

    public StringWithCharIterator(string str) => this.str = str;

    public char nextChar => str[index++];
}
