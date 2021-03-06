﻿using DataAccessLayer;
using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class RoomHandler
    {
        IRoomRepository db = new RoomRepository();

        public RoomModel Add(RoomModel entity)
        {
            return db.Add(entity);
        }

        public void Delete(int id)
        {
             db.Remove(id);
        }

        public RoomModel Get(int id)
        {
            return db.Find(id);
        }

        public IEnumerable<RoomModel> GetAll()
        {
            return db.GetAll();
        }

        public int Update(RoomModel entity)
        {
            return db.Update(entity);
        }

        public IEnumerable<RoomModel> GetAllAvailable()
        {
            return db.GetAllAvailable();
        }

        public bool isAvailable(int id)
        {
            RoomModel room = db.Find(id);
            if(room.IsAvailable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckDateOfModification(DateTime dateTime, int id)
        {
            return db.CheckDateOfModification(dateTime, id);
        }

        public void ChangeRoomAvailability(int roomId, bool available)
        {
            db.ChangeRoomAvailability(roomId, false);
        }
    }
}
