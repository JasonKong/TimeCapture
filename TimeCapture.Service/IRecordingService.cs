using TimeCapture.Models;

namespace TimeCapture.Service
{
    interface IRecordingService
    {
        void InsertRecording(RecordViewModel model);
        void UpdateRecording(RecordViewModel model);
        void DeleteRecording(RecordViewModel model);
    }
}
