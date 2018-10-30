using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurStory.IService.Base
{
    public interface IStudentSubscriberService
    {
        Task ConsumeStudentMessage(object message);
    }
}
