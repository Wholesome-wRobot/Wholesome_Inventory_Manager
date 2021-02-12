﻿using System;
using System.Windows;
using static WAEEnums;

namespace Wholesome_Inventory_Manager.Settings
{
    public partial class PluginSettingsControl
    {
        public PluginSettingsControl()
        {
            InitializeComponent();

            if (AutoEquipSettings.CurrentSettings.SpecSelectedByUser == ClassSpec.None)
                Main.AutoDetectMyClassSpec();

            // AUTO EQUIP
            AutoDetectStatWeights.IsChecked = AutoEquipSettings.CurrentSettings.AutoDetectStatWeights;

            AutoEquipGear.IsChecked = AutoEquipSettings.CurrentSettings.AutoEquipGear;
            AutoEquipBags.IsChecked = AutoEquipSettings.CurrentSettings.AutoEquipBags;

            EquipQuiver.IsChecked = AutoEquipSettings.CurrentSettings.EquipQuiver;
            EquipThrown.IsChecked = AutoEquipSettings.CurrentSettings.EquipThrown;
            EquipBows.IsChecked = AutoEquipSettings.CurrentSettings.EquipBows;
            EquipGuns.IsChecked = AutoEquipSettings.CurrentSettings.EquipGuns;
            EquipCrossbows.IsChecked = AutoEquipSettings.CurrentSettings.EquipCrossbows;

            EquipOneHanders.IsChecked = AutoEquipSettings.CurrentSettings.EquipOneHanders;
            EquipTwoHanders.IsChecked = AutoEquipSettings.CurrentSettings.EquipTwoHanders;
            EquipShields.IsChecked = AutoEquipSettings.CurrentSettings.EquipShields;

            // STATS
            StatsPreset.ItemsSource = Enum.GetNames(typeof(ClassSpec));
            GroupStats.IsEnabled = !(bool)AutoDetectStatWeights.IsChecked;

            UpdateStats();
        }

        private void EquipShieldsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipShields = (bool)EquipShields.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipTwoHandersChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipTwoHanders = (bool)EquipTwoHanders.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipOneHandersChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipOneHanders = (bool)EquipOneHanders.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AutoDetectStatsPresetChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SpecSelectedByUser = (ClassSpec)Enum.Parse(typeof(ClassSpec), StatsPreset.SelectedIndex.ToString());
            SettingsPresets.ChangeStatsWeightSettings(AutoEquipSettings.CurrentSettings.SpecSelectedByUser);
            UpdateStats();
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AutoDetectStatWeightsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.AutoDetectStatWeights = (bool)AutoDetectStatWeights.IsChecked;
            GroupStats.IsEnabled = !(bool)AutoDetectStatWeights.IsChecked;
            Main.AutoDetectMyClassSpec();
            SettingsPresets.ChangeStatsWeightSettings(AutoEquipSettings.CurrentSettings.SpecSelectedByUser);
            UpdateStats();
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void Mana5WeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.ManaPer5, (int)Mana5Weight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ArmorWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Armor, (int)ArmorWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ResilienceWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.ResilienceRating, (int)ResilienceWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void DodgeRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.DodgeRating, (int)DodgeRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ParryRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.ParryRating, (int)ParryRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void DefenseRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.DefenseRating, (int)DefenseRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ShieldBlockWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.BlockValue, (int)ShieldBlockRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ShieldBlockRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.BlockRating, (int)ShieldBlockRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void SpellPenetrationWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.SpellPenetration, (int)SpellPenetrationWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ArmorPenetrationWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.ArmorPenetrationRating, (int)ArmorPenetrationWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void ExpertiseRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.ExpertiseRating, (int)ExpertiseRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void HitRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.HitRating, (int)HitRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void HasteRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.HasteRating, (int)HasteRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void CritRatingWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.CriticalStrikeRating, (int)CritRatingWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void SpellPowerWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.SpellPower, (int)SpellPowerWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AttackPowerWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.AttackPower, (int)AttackPowerWeight.Value);
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.AttackPowerinForms, (int)AttackPowerWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void DPSWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.DamagePerSecond, (int)DPSWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AgilityWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Agility, (int)AgilityWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void SpiritWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Spirit, (int)SpiritWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void IntellectWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Intellect, (int)IntellectWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void StrengthWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Strength, (int)StrengthWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void StaminaWeightChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.SetStat(CharStat.Stamina, (int)StaminaWeight.Value);
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipCrossbowsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipCrossbows = (bool)EquipCrossbows.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipGunsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipGuns = (bool)EquipGuns.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipBowsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipBows = (bool)EquipBows.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipThrownChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipThrown = (bool)EquipThrown.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void EquipQuiverChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.EquipQuiver = (bool)EquipQuiver.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AutoEquipBagsChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.AutoEquipBags = (bool)AutoEquipBags.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void AutoEquipGearChanged(object sender, RoutedEventArgs e)
        {
            AutoEquipSettings.CurrentSettings.AutoEquipGear = (bool)AutoEquipGear.IsChecked;
            AutoEquipSettings.CurrentSettings.Save();
        }

        private void UpdateStats()
        {
            StatsPreset.SelectedValue = AutoEquipSettings.CurrentSettings.SpecSelectedByUser.ToString();

            // Base stats
            StaminaWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Stamina);
            StrengthWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Strength);
            IntellectWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Intellect);
            SpiritWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Spirit);
            AgilityWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Agility);
            DPSWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.DamagePerSecond);
            // Advanced stats
            AttackPowerWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.AttackPower);
            SpellPowerWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.SpellPower);
            CritRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.CriticalStrikeRating);
            HasteRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.HasteRating);
            HitRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.HitRating);
            ExpertiseRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.ExpertiseRating);
            // Expert stats
            ArmorPenetrationWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.ArmorPenetrationRating);
            SpellPenetrationWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.SpellPenetration);
            ShieldBlockRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.BlockRating);
            ShieldBlockWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.BlockValue);
            DefenseRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.DefenseRating);
            ParryRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.ParryRating);
            DodgeRatingWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.DodgeRating);
            ResilienceWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.ResilienceRating);
            ArmorWeight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.Armor);
            Mana5Weight.Value = AutoEquipSettings.CurrentSettings.GetStat(CharStat.ManaPer5);
        }
    }
}