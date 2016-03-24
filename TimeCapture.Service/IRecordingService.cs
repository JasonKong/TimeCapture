using TimeCapture.Models;

namespace TimeCapture.Service
{
    interface IRecordingService
    {
        void InsertRecording(Recording model);
        void UpdateRecording(Recording model);
        void DeleteRecording(Recording model);
    }
}
