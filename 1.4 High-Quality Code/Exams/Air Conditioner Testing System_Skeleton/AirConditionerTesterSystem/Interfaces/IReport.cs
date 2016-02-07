namespace AirConditionerTesterSystem.Interfaces
{
    /// <summary>
    /// Interface containing members for air conditioner report.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Gets or sets the air conditioner manufacturer.
        /// </summary>
        /// <value>
        /// The air conditioner manufacturer.
        /// </value>
        string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the air conditioner model.
        /// </summary>
        /// <value>
        /// The air conditioner manufacturer.
        /// </value>
        string Model { get; set; }

        /// <summary>
        /// Holds weather the air conditioner has passed its test.
        /// </summary>
        /// <value>
        /// Holds weather the air conditioner has passed its test.
        /// </value>
        bool HasPassedTest { get; }

        /// <summary>
        /// Returns the report as string.
        /// See also <see cref="System.String" />
        /// </summary>
        /// <returns>
        /// The report as string.
        /// </returns>
        string ToString();
    }
}
