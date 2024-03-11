﻿using Microsoft.AspNetCore.Mvc;
using STPL_API.BusinessLogic;
using STPL_API.DataAccessLayer;
using System.Text;

namespace STPL_API.Controllers
{
    [Route("v1/[controller]")]
    public class RecordTransactionController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;

        public RecordTransactionController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }
        /// <summary>
        /// SaveData
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost("SaveData", Name = "SaveData")]

        public SaveDataResponseBuilder SaveData([FromBody] Newtonsoft.Json.Linq.JObject param)
        {
            try
            {
                dynamic requestData = param;
                if (requestData != null)
                {
                    int deviceid = _repositoryWrapper.deviceReporitory.CheckAndCreateNewDevice(requestData.deviceId.Value, requestData.deviceType.Value, requestData.deviceName.Value, requestData.groupId.Value, "web");
                    if (deviceid>0)
                    {
                        bool? fullPowerMode = requestData.data.fullPowerMode != null ? requestData.data.fullPowerMode.Value : null;
                        bool? activePowerControl = requestData.data.activePowerControl != null ? requestData.data.activePowerControl.Value : null;
                        int? firmwareVersion = requestData.data.firmwareVersion != null ? int.Parse(requestData.data.firmwareVersion.Value.ToString()) : null;
                        int? temperature = requestData.data.temperature != null ? int.Parse(requestData.data.temperature.Value.ToString()) : null;
                        int? humidity = requestData.data.humidity != null ? int.Parse(requestData.data.humidity.Value.ToString()) : null;
                        int? version = requestData.data.version != null ? int.Parse(requestData.data.version.Value.ToString()) : null;
                        string messageType = requestData.data.messageType != null ? requestData.data.messageType.Value : null;
                        bool? occupancy = requestData.data.occupancy != null ? requestData.data.occupancy.Value : null;
                        int? stateChanged = requestData.data.stateChanged != null ? int.Parse(requestData.data.stateChanged.Value.ToString()) : null;
                        //TimeSpan timeSpan = TimeSpan.FromSeconds(requestData.timestamp.Value);


                        int referenceno = _repositoryWrapper.reqTransRepository.CreateNewRecordTransaction(_repositoryWrapper, "web", deviceid, requestData.timestamp.Value, requestData.dataType.Value, fullPowerMode, activePowerControl, firmwareVersion, temperature, humidity, version, messageType, occupancy, stateChanged);
                        if (referenceno > 0)
                        {
                            string sref = referenceno+DateTime.Now.ToString("yyyyMMddHHmmss")+ "uR!#2p9Q&8Ls";
                            sref= Convert.ToBase64String(Encoding.UTF8.GetBytes(sref));
                            return new SaveDataResponseBuilder { status = 201, message = "Save Successfully", data = new { referenceno = sref, response_datetime=DateTime.Now } };
                        }
                        else
                        {
                            return new SaveDataResponseBuilder { status = 500, message = "Internal Server Error", data = new { } };
                        }
                    }
                    else
                    {
                        return new SaveDataResponseBuilder { status = 500, message = "Internal Server Error", data = new { } };
                    }
                }
                else
                {
                    return new SaveDataResponseBuilder { status = 400, message = "Invalid Request Body", data = new { } };
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "SaveData" + Environment.NewLine + ex.StackTrace);
                return new SaveDataResponseBuilder { status = 500, message = "Internal Server Error", data = new { } };
            }
        }
    }
}
