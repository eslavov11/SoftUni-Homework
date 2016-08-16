import annotation.BurnableGarbageAnnotation;
import annotation.RecyclableGarbageAnnotation;
import model.garbageDisposalStrategy.BurnableGarbageDisposalStrategy;
import model.garbageDisposalStrategy.RecyclableGarbageDisposalStrategy;
import model.processingData.RecyclingStationProcessingData;
import model.waste.RecyclableGarbage;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.mockito.Mockito;
import wasteDisposal.Contracts.GarbageProcessor;
import wasteDisposal.Contracts.ProcessingData;
import wasteDisposal.Contracts.StrategyHolder;
import wasteDisposal.Contracts.Waste;
import wasteDisposal.DefaultGarbageProcessor;
import wasteDisposal.DefaultStrategyHolder;

/**
 * Created by Edi on 07-Aug-16.
 */
public class GarbageProcessorTests {
    private GarbageProcessor garbageProcessor;

    @Before
    public void setUp() {
        this.garbageProcessor = new DefaultGarbageProcessor();
    }

    @Test
    public void testGetStrategyHolder_addedEmptyHolder_referencesShouldMatch() {
        StrategyHolder strategyHolder = new DefaultStrategyHolder();
        this.garbageProcessor = new DefaultGarbageProcessor(strategyHolder);

        StrategyHolder resultedHolder = this.garbageProcessor.getStrategyHolder();

        Assert.assertEquals("Strategy holder references should be equal", strategyHolder, resultedHolder);
    }

    @Test
    public void testProcessWaste_correctData_shouldReturnProcessingData() {
        StrategyHolder strategyHolder = new DefaultStrategyHolder();
        strategyHolder.addStrategy(RecyclableGarbageAnnotation.class, new RecyclableGarbageDisposalStrategy());

        this.garbageProcessor = Mockito.mock(DefaultGarbageProcessor.class);
        Mockito.when(this.garbageProcessor.getStrategyHolder()).thenReturn(strategyHolder);
        Waste waste = new RecyclableGarbage("Name", 0, 0);
        ProcessingData pd = null;

        ProcessingData resultData = this.garbageProcessor.processWaste(waste);

        Assert.assertEquals("Processing data should match", pd, resultData);
    }

    @Test(expected = IllegalArgumentException.class)
    @SuppressWarnings("unchecked")
    public void testProcessWaste_wasteNotDisposable_shouldThrow() {
        Waste waste = new RecyclableGarbage("Name", 0, 0);

        this.garbageProcessor = Mockito.mock(DefaultGarbageProcessor.class);
        Mockito.when(this.garbageProcessor.processWaste(Mockito.any(Waste.class))).thenThrow(IllegalArgumentException.class);

        this.garbageProcessor.processWaste(waste);
    }
}
