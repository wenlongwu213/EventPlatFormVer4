﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EventPlatFormVer4.Models
{
    public class Participant
    {
        //不显示
        [Key]
        public string ID { get; set; }//唯一ID
        public uint RoleID { get; set; }//参赛者角色=2
        
        //登录用
        public string Name { get; set; }//账号;个人信息展示

        public string PassWd { get; set; }//密码

        //个人信息展示
        public string Email { get; set; }//邮箱

        public string PhoneNum { get; set; }//电话号码

        //参加的活动
        [ForeignKey("EventID")]
        public List<Event> PartiEvent { get;set; }


        public Participant()
        {
            ID = Guid.NewGuid().ToString();//ID唯一性
            RoleID = 2;
            PartiEvent = new List<Event>();
        }
        public Participant(List<Event> events) : this()
        {
            if (events != null) PartiEvent = events;
        }

        public override bool Equals(object obj)
        {
            var participant = obj as Participant;
            return participant != null && Name == participant.Name && Email == participant.Email && PhoneNum == participant.PhoneNum;
        }
        public override int GetHashCode()
        {
            return 123456789 + ID.GetHashCode() + RoleID.GetHashCode();
        }

        public override string ToString()//提取参赛者信息
        {
            return "姓名：" + Name + "\n" + "邮箱地址：" + Email + "\n" + "电话号码：" + PhoneNum + "\n";
        }
    }
    
}
