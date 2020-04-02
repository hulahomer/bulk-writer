﻿using System;
using Microsoft.Extensions.Logging;

namespace BulkWriter.Pipeline.Internal
{
    internal class EtlPipelineContext
    {
        private readonly Action<IEtlPipelineStep> _addStepToPipelineAction;

        public EtlPipelineContext(IEtlPipeline etlPipeline, Action<IEtlPipelineStep> addStepToPipelineAction)
        {
            Pipeline = etlPipeline;
            _addStepToPipelineAction = addStepToPipelineAction;
        }

        public IEtlPipeline Pipeline { get; }
        public ILoggerFactory LoggerFactory { get; set; }

        public void AddStep(IEtlPipelineStep step)
        {
            _addStepToPipelineAction(step);
        }
    }
}