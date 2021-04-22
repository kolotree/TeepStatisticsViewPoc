using System;
using System.Collections.Generic;

namespace TestApp
{
    public sealed class MachineCycleDetected : IEvent
    {
        public string MachineName { get; }
        public DateTime Timestamp { get; }

        public MachineCycleDetected(
            string machineName,
            DateTime timestamp)
        {
            MachineName = machineName;
            Timestamp = timestamp;
        }

        public IReadOnlyList<string> ViewId => new List<string> {$"{MachineName}_{Timestamp.TotalHours()}"};
    }

    public sealed class MachineStopped : IEvent
    {
        public string MachineName { get; }
        public DateTime StoppedAt { get; }

        public MachineStopped(
            string machineName,
            DateTime stoppedAt)
        {
            MachineName = machineName;
            StoppedAt = stoppedAt;
        }
        
        public IReadOnlyList<string> ViewId => new List<string> {$"{MachineName}_{StoppedAt.TotalHours()}"};
    }
    
    public sealed class MachineStoppageTypeDefined : IEvent
    {
        public string MachineName { get; }
        public DateTime StoppedAt { get; }
        public DateTime? StoppageFinishedAt { get; }
        public string Type { get; }

        public MachineStoppageTypeDefined(
            string machineName,
            DateTime stoppedAt,
            DateTime? stoppageFinishedAt,
            string type)
        {
            MachineName = machineName;
            StoppedAt = stoppedAt;
            StoppageFinishedAt = stoppageFinishedAt;
            Type = type;
            
        }
        
        public IReadOnlyList<string> ViewId
        {
            get
            {
                var resultList = new List<string> {$"{MachineName}_{StoppedAt.TotalHours()}"};
                if (StoppageFinishedAt.HasValue)
                {
                    for (var i = StoppedAt.TotalHours() + 1; i <= StoppageFinishedAt.Value.TotalHours(); ++i)
                    {
                        resultList.Add($"{MachineName}_{i}");    
                    }
                }
                return resultList;
            }
        }
    }
    
    public sealed class MachineStarted : IEvent
    {
        public string MachineName { get; }
        public DateTime StartedAt { get; }
        public DateTime LastStoppedAt { get; }

        public MachineStarted(
            string machineName,
            DateTime startedAt,
            DateTime lastStoppedAt)
        {
            MachineName = machineName;
            StartedAt = startedAt;
            LastStoppedAt = lastStoppedAt;
        }
        
        public IReadOnlyList<string> ViewId => new List<string> {$"{MachineName}_{StartedAt.TotalHours()}"};
    }
}