using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SaveGroup
{
	public int Level;
	public int Exp;
	public string PlayTime;
	public string SaveArea;
	public int SavePoint;
	public SaveGroup(string p_level , string p_exp , string p_time , string p_saveArea , string p_savePoint)
	{
		Level = int.Parse(p_level);
		Exp = int.Parse(p_exp);
		PlayTime = p_time;
		SaveArea = p_saveArea;
		SavePoint = int.Parse(p_savePoint);
	}
	public SaveGroup()
	{
	}
}

public static class GameSaveXML
{
	static string filepath = Application.dataPath + @"/Save/Save.xml";
	//static TextAsset resfilepath = (TextAsset)Resources.Load("GameSave/Save",typeof(TextAsset));//Resources路徑

	public static void CheckXML()
	{
		if (!Directory.Exists(Application.dataPath + @"/Save"))
		{
			Debug.Log("沒有資料夾,建立資料夾");
			Directory.CreateDirectory(Application.dataPath + @"/Save");
		}
		//判断路徑是否有文件存在
		if(!File.Exists (filepath))
		{
			//沒有文件存在,則新增文件
			XmlDocument xmlDoc = new XmlDocument();
			//建立基本物品架構
			XmlElement root = xmlDoc.CreateElement("GameSave");
			XmlElement SaveNum = xmlDoc.CreateElement("SaveBasic");
			XmlElement Player_Level = xmlDoc.CreateElement("Level");
			Player_Level.InnerText = "1";
			XmlElement Player_Exp = xmlDoc.CreateElement("Exp");
			Player_Exp.InnerText = "0";
			XmlElement PLayer_Time = xmlDoc.CreateElement("PlayerTime");
			PLayer_Time.InnerText = "00:00";
			XmlElement PLayer_SaveArea = xmlDoc.CreateElement("SaveArea");
			PLayer_SaveArea.InnerText = "永遠亭";
			XmlElement PLayer_SavePoint = xmlDoc.CreateElement("SavePoint");
			PLayer_SavePoint.InnerText = "0";
			
			//建構層級
			SaveNum.AppendChild(Player_Level);
			SaveNum.AppendChild(Player_Exp);
			SaveNum.AppendChild(PLayer_Time);
			SaveNum.AppendChild(PLayer_SaveArea);
			SaveNum.AppendChild(PLayer_SavePoint);
			root.AppendChild(SaveNum);
			xmlDoc.AppendChild(root);
			//存檔
			xmlDoc.Save(filepath);
			#if UNITY_EDITOR
			AssetDatabase.Refresh();
			#endif
			Debug.Log("沒有XML文件,創建文件成功");
		}
	}
	//新增存檔
	public static void AddSave(string saveNum , string p_level , string p_exp , string p_time , string p_saveArea , string p_savePoint)
	{
		//確認檔案
		CheckXML();

		XmlDocument xmlDoc = new XmlDocument();
		//resfilepath = (TextAsset)Resources.Load("GameSave/Save",typeof(TextAsset));
		//xmlDoc.LoadXml(resfilepath.text);
		xmlDoc.Load(filepath);

		//建立基本物品架構
		XmlNode xml_root = xmlDoc.SelectSingleNode("GameSave");
		XmlElement SaveNum = xmlDoc.CreateElement("Save0" + saveNum);
		XmlElement Player_Level = xmlDoc.CreateElement("Level");
		Player_Level.InnerText = p_level;
		XmlElement Player_Exp = xmlDoc.CreateElement("Exp");
		Player_Exp.InnerText = p_exp;
		XmlElement PLayer_Time = xmlDoc.CreateElement("PlayerTime");
		PLayer_Time.InnerText = p_time;
		XmlElement PLayer_SaveArea = xmlDoc.CreateElement("SaveArea");
		PLayer_SaveArea.InnerText = p_saveArea;
		XmlElement PLayer_SavePoint = xmlDoc.CreateElement("SavePoint");
		PLayer_SavePoint.InnerText = p_savePoint;
		
		//建構層級
		SaveNum.AppendChild(Player_Level);
		SaveNum.AppendChild(Player_Exp);
		SaveNum.AppendChild(PLayer_Time);
		SaveNum.AppendChild(PLayer_SaveArea);
		SaveNum.AppendChild(PLayer_SavePoint);
		xml_root.AppendChild(SaveNum);
		xmlDoc.AppendChild(xml_root);
		//存檔
		xmlDoc.Save(filepath);
		#if UNITY_EDITOR
		AssetDatabase.Refresh();
		#endif
		Debug.Log("存檔完成 : " + saveNum);
	}
	//覆蓋存檔
	public static void CoverSave(string saveNum , string p_level , string p_exp , string p_time , string p_saveArea , string p_savePoint)
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(filepath);

		XmlNodeList save_root = xmlDoc.SelectSingleNode("GameSave").ChildNodes;
		//讀取所有存檔
		foreach(XmlElement save in save_root)
		{
			if (save.Name == "Save0"+saveNum)
			{
				save.SelectSingleNode("Level").InnerText = p_level;
				save.SelectSingleNode("Exp").InnerText = p_exp;
				save.SelectSingleNode("PlayerTime").InnerText = p_time;
				save.SelectSingleNode("SaveArea").InnerText = p_saveArea;
				save.SelectSingleNode("SavePoint").InnerText = p_savePoint;

				//存檔
				xmlDoc.Save(filepath);
				#if UNITY_EDITOR
				AssetDatabase.Refresh();
				#endif
				Debug.Log("存檔更新完成 :"+saveNum);
				break;
			}
		}
	}

	public static SaveGroup GetSave(string saveNum)
	{
		//確認檔案
		CheckXML();

		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(filepath);
		SaveGroup savegroup = new SaveGroup();

		bool HasSave = false;
		XmlNodeList save_root = xmlDoc.SelectSingleNode("GameSave").ChildNodes;
		//讀取所有存檔
		foreach(XmlElement save in save_root)
		{
			if (save.Name == "Save0"+saveNum)
			{
				HasSave = true;
				savegroup = new SaveGroup(
					save.SelectSingleNode("Level").InnerText,
					save.SelectSingleNode("Exp").InnerText,
					save.SelectSingleNode("PlayerTime").InnerText,
					save.SelectSingleNode("SaveArea").InnerText,
					save.SelectSingleNode("SavePoint").InnerText);
			}
		}
		if (HasSave) return savegroup;
		else return null;
	}

	public static int GetSaveCount()
	{
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(filepath);
		//SaveGroup savegroup = new SaveGroup();

		XmlNodeList save_root = xmlDoc.SelectSingleNode("GameSave").ChildNodes;
		return save_root.Count-1;
	}
	//檢查存檔編號
	public static bool CheckSaveNum(string Num)
	{
		//確認檔案
		CheckXML();
		
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.Load(filepath);
		//SaveGroup savegroup = new SaveGroup();
		
		//bool HasSave = false;
		XmlNodeList save_root = xmlDoc.SelectSingleNode("GameSave").ChildNodes;
		//讀取所有存檔
		foreach(XmlElement save in save_root)
		{
			if (save.Name == "Save0"+Num)
			{
				return true;
			}
		}
		return false;
	}
}