using Microsoft.AspNetCore.Components;
using TrainingLog.Client.Infrastructure.Managers;
using TrainingLog.Client.Shared;
using TrainingLog.Shared.Dtos;

namespace TrainingLog.Client.Pages;

public partial class Index
{
    [Inject]
    private ITrainingEventManager TrainingEventManager { get; set; }

    private List<TrainingEventDto> _trainingEvents = new ();
    private bool _showAddModal;
    private ModalWrapper AddLogEventModal{get;set;}
    protected override async Task OnInitializedAsync()
    {
        await LoadTrainingEvents();
    }

    private async Task LoadTrainingEvents()
    {
        _trainingEvents = await TrainingEventManager.GetAllTrainingEvents();
    }

    private void ShowAddModal()
    {
        _showAddModal = true;
        AddLogEventModal.Open();
    }

    private async Task TrainingLogSaved()
    {
        AddLogEventModal.Close();
        _showAddModal = false;
        await LoadTrainingEvents();
    }

}