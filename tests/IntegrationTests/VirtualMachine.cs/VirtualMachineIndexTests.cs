using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Shouldly;

namespace IntegrationTests;

[Parallelizable(ParallelScope.Self)]
public class VirtualMachineIndexTests : PageTest
{
    [Test]
    public async Task Show_Index_With_3_Items_On_Load()
    {
        await Page.GotoAsync($"{TestHelper.BaseUri}/virtualmachines/");
        await Page.WaitForSelectorAsync("data-test-id=virtualmachine-overview");
        await Page.ClickAsync("data-test-id=virtualmachine-button");
        var amountOfVirtualMachine = await Page.Locator("data-test-id=virtualmachine-item").CountAsync();
        amountOfVirtualMachine.ShouldBe(3);
    }
}
