namespace Demo.Model
{
    public interface IDemoImageHash
    {
        ulong CalculatePerceptualHash(string filename);
    }
}
