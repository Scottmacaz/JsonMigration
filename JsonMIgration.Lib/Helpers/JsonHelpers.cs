using Newtonsoft.Json.Linq;
using Semver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.JsonMigrations.Helpers
{
    public class JsonHelpers
    {
        public static SemVersion GetSemVersionFromJson(string json)
        {
            //parse the json string and retrieve the version.
            var jObject = JObject.Parse(json);
            var importVersion = jObject["Version"].ToString();
            if (importVersion == null)
            {
                throw new System.Exception("Unable to find Version in JSON");
            }

            var chaps = jObject["Chapters"];
            foreach (var chap in chaps)
            {
                var jo = JObject.Parse(chap.ToString());
                var fieldValue = jo["Number"];
                jo.Remove("Number");
                jo["Num"] = fieldValue;
            }
                       
            var versionPieces = importVersion.Split('.');
            if (versionPieces.Length < 3)
            {
                throw new Exception("Version needs at least three numbers");
            }
            var majorParse = int.TryParse(versionPieces[0], out int major);
            if (!majorParse)
            {
                throw new Exception($"Major position of Version is not a valid int: {versionPieces[0]}");
            }

            var minorParse = int.TryParse(versionPieces[1], out int minor);
            if (!minorParse)
            {
                throw new Exception($"Minor position of Version is not a valid int: {versionPieces[1]}");
            }

            var patchParse = int.TryParse(versionPieces[2], out int patch);
            if (!patchParse)
            {
                throw new Exception($"Patch position of Version is not a valid int: {versionPieces[2]}");
            }
            return new SemVersion(major: major, minor: minor, patch: patch);
        }
    }
}
