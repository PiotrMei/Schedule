﻿namespace ScheduleApp.Primitives
{
    public interface IQuery<out TResult> : MediatR.IRequest<TResult> { }
}
