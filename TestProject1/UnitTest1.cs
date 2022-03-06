using ISCAnalyser;
using ISCAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static ISCAnalyser.POCO.CensusAnalyser;

namespace TestProject1
{
    public class Tests
    {
        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"E:\github\IndianStateCensusAnalyser\ISCAnalyser\CSV\IndianStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"E:\github\IndianStateCensusAnalyser\ISCAnalyser\CSV\WrongIndianStateCensusData.csv";
        static string delimeterIndianCensusFilePath = @"E:\github\IndianStateCensusAnalyser\ISCAnalyser\CSV\DelimiterIndianStateCensusData.csv";
        static string wrongIndianCensusFileType = @"E:\github\IndianStateCensusAnalyser\ISCAnalyser\CSV\IndianStateCensusData.txt";
        static string invalidPath;

        CensusAnalyser censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //Happy Test Case : the records are checked
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case : to verify if the exception is raised.
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
           var totalRecord = Assert.Throws<CensusAnalyserException>(() =>censusAnalyzer.LoadCensusData(Country.INDIA,invalidPath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND,totalRecord.exType);
        }

        //Sad Test Case : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileTypeWrong_WhenRead_ShouldReturnException()
        {
            
           var totalRecord= Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianCensusFileType, indianStateCensusHeaders));

            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, totalRecord.exType);
        }

        //Sad Test Case : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileDelimeterWrong_WhenRead_ShouldReturnException()
        {
            var totalRecord =Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER, totalRecord.exType);
        }

        //Sad Test Case : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileCsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            var totalRecord =Assert.Throws<CensusAnalyserException>(() => censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECR_HEADER, totalRecord.exType);
        }
    }
        
}