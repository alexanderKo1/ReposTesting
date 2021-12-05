using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();

            OpenGroupsDialog();

            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51"
                , "GetItemCount", "#0", "");

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51"
                , "GetText", "#0|#" + i, "");

                list.Add(new GroupData()
                {
                    Name = item
                });
            }

            CloseGroupsDialog();

            return list;
        }

        internal void GroupRemoving(int indexer)
        {
            OpenGroupsDialog();

            //1. выбор элемента
            aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51"
                , "Select", "#0|#" + indexer, "");

            //2. Нажатие на кнопку 'Delete'
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            // Ожидание окна
            aux.WinWaitActive(GROUPWINTITLE, "", 5);

            //3. Выбор второго чек-бокса
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");

            //4. Нажатие кнопки ОК
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");

            // Ожидание окна
            aux.WinWaitActive(DELETEGROUPWINTITLE, "", 5);

            CloseGroupsDialog();
        }

        internal void GroupRemovingCondition()
        {
            if (GetGroupList().Count == 1)
            {
                GroupData newGroup = new GroupData() { Name = "GroupForRemoving" };

                OpenGroupsDialog();
                aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53"); //-11.38
                aux.Send(newGroup.Name);
                aux.Send("{ENTER}");
                CloseGroupsDialog();
            }
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53"); //-11.38
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            CloseGroupsDialog();
        }

        private void CloseGroupsDialog()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }
        public void GroupMonitor(List<GroupData> groups)
        {
            int nn = 0;
            foreach (GroupData element in groups)
            {
                System.Console.Out.Write((++nn) + " | " + element.Name);
            }
            System.Console.Out.Write("FINISHED" + "\n");
        }
    }
}