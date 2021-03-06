﻿using robotManager.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using wManager;
using wManager.Wow.Helpers;
using static WAEEnums;

public class ToolBox
{
    public static bool ImACaster()
    {
        return WAECharacterSheet.ClassSpec == ClassSpec.DruidBalance
            || WAECharacterSheet.ClassSpec == ClassSpec.DruidRestoration
            || WAECharacterSheet.ClassSpec == ClassSpec.MageArcane
            || WAECharacterSheet.ClassSpec == ClassSpec.MageFire
            || WAECharacterSheet.ClassSpec == ClassSpec.MageFrost
            || WAECharacterSheet.ClassSpec == ClassSpec.PaladinHoly
            || WAECharacterSheet.ClassSpec == ClassSpec.PriestDiscipline
            || WAECharacterSheet.ClassSpec == ClassSpec.PriestHoly
            || WAECharacterSheet.ClassSpec == ClassSpec.PriestShadow
            || WAECharacterSheet.ClassSpec == ClassSpec.ShamanElemental
            || WAECharacterSheet.ClassSpec == ClassSpec.ShamanRestoration
            || WAECharacterSheet.ClassSpec == ClassSpec.WarlockAffliction
            || WAECharacterSheet.ClassSpec == ClassSpec.WarlockDemonology
            || WAECharacterSheet.ClassSpec == ClassSpec.WarlockDestruction;
    }

    public static void AddToDoNotSellList(string itemName)
    {
        if (!wManagerSetting.CurrentSetting.DoNotSellList.Contains(itemName))
            wManagerSetting.CurrentSetting.DoNotSellList.Add(itemName);
    }

    // Returns whether the player has the debuff passed as a string (ex: Weakened Soul)
    public static bool HasDebuff(string debuffName, string unitName = "player")
    {
        return Lua.LuaDoString<bool>
            ($@"for i=1,25 do
                    local n, _, _, _, _  = UnitDebuff('{unitName}',i);
                    if n == '{debuffName}' then
                    return true
                    end
                end");
    }

    public static void Restart()
    {
        new Thread(() =>
        {
            Products.ProductStop();
            ToolBox.Sleep(2000);
            Products.ProductStart();
        }).Start();
    }

    public static bool WEEquipToolTipExists()
    {
        return !Lua.LuaDoString<bool>("return WEquipTooltip == nil;");
    }

    public static void RemoveFromDoNotSellList(string itemName)
    {
        if (wManagerSetting.CurrentSetting.DoNotSellList.Contains(itemName))
            wManagerSetting.CurrentSetting.DoNotSellList.Remove(itemName);
    }

    public static WoWVersion GetWoWVersion()
    {
        string version = Lua.LuaDoString<string>("v, b, d, t = GetBuildInfo(); return v");
        if (version == "2.4.3")
            return WoWVersion.TBC;
        else
            return WoWVersion.WOTLK;
    }

    public static int GetTalentRank(int tabIndex, int talentIndex)
    {
        int rank = Lua.LuaDoString<int>($"local _, _, _, _, currentRank, _, _, _ = GetTalentInfo({tabIndex}, {talentIndex}); return currentRank;");
        return rank;
    }


    // Gets Character's specialization (by Marsbar) Modified to return 0 if all talent trees have 0 point
    public static int GetSpec()
    {
        var Talents = new Dictionary<int, int>();
        for (int i = 0; i <= 3; i++)
        {
            Talents.Add(
                i,
                Lua.LuaDoString<int>($"local name, iconTexture, pointsSpent = GetTalentTabInfo({i}); return pointsSpent")
            );
        }
        int highestTalents = Talents.Max(x => x.Value);
        return Talents.Where(t => t.Value == highestTalents).FirstOrDefault().Key;
    }

    public static void Sleep(int milliseconds)
    {
        int worldLatency = Lua.LuaDoString<int>($"local down, up, lagHome, lagWorld = GetNetStats(); return lagWorld");
        int homeLatency = Lua.LuaDoString<int>($"local down, up, lagHome, lagWorld = GetNetStats(); return lagHome");
        Thread.Sleep(worldLatency + homeLatency + milliseconds);
    }

    public enum WoWVersion
    {
        VANILLA,
        TBC,
        WOTLK
    }
}