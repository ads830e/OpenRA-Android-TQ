
namespace OpenRA_Mod_Common_ForceDependence {
	public class ForceDependence
	{
        OpenRA.Mods.Cnc.CncLoadScreen a=null;
        OpenRA.Mods.Cnc.FileSystem.MixLoader b =null;

        public void ForceDependenceFunc()
        {
            a = null;
            b = null;

            var a_class = typeof(OpenRA.Mods.Cnc.CncLoadScreen);
            var b_class = typeof(OpenRA.Mods.Cnc.FileSystem.MixLoader);
        }
	}
	
}
