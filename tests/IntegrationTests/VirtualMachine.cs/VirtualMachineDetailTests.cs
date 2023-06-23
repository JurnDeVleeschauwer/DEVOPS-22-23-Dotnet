using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class VirtualMachineDetailTests : PageTest
{
    [Test]
    public async Task Show_VirtualMachine_Detail_OnLoad()
    {
        await Page.GotoAsync($"{TestHelper.BaseUri}/virtualmachine/1");
        await Page.WaitForSelectorAsync("data-test-id=virtualmachine-detail-title");
        var VirtualMachineTitle = await Page.TextContentAsync("data-test-id=virtualmachine-detail-title");
        VirtualMachineTitle.ShouldNotBeEmpty();
    }
}
