using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TrainingLog.Client.Infrastructure.Managers;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Client.Shared;

public partial class AddNewLogEvent
{
    [Parameter] public EventCallback<bool> OnSaveSuccessful { get; set; }

    [Inject] public ITrainingEventManager TrainingEventManager { get; set; }

    private NewTrainingEventDto _newEvent = new() { EventDate = DateTime.Today };

    private EditContext _editContext;

    private List<EventTypeDto> _eventTypeList = new();

    protected override async Task OnInitializedAsync()
    {
        _editContext = new EditContext(_newEvent);
        await LoadEventTypes();
    }

    private async Task LoadEventTypes()
    {
        _eventTypeList = await TrainingEventManager.GetEventTypes();
    }

    private async Task SaveLog()
    {
        var isSuccess = await TrainingEventManager.InsertTrainingEvent(_newEvent);
        if (isSuccess)
            await OnSaveSuccessful.InvokeAsync();
    }
}