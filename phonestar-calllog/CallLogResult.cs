namespace phonestar_calllog
{
    public class CallLogResult
    {
        public CallLogResult()
        {
            data = new List<CallLogEntry>();
        }
        public string status { get; set; }
        public List<CallLogEntry> data { get; set; }
    }
}
