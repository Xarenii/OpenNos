﻿/*
 * This file is part of the OpenNos Emulator Project. See AUTHORS file for Copyright information
 *
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 */

using OpenNos.Domain;
using System;

namespace OpenNos.GameObject
{
    public abstract class MapItem
    {
        #region Members

        protected ItemInstance _itemInstance;
        private long _transportId;

        #endregion

        #region Instantiation

        public MapItem(short x, short y)
        {
            PositionX = x;
            PositionY = y;
            CreateDate = DateTime.Now;
            TransportId = 0;
        }

        #endregion

        #region Properties

        public DateTime CreateDate { get; set; }

        public short PositionX { get; set; }

        public short PositionY { get; set; }

        public abstract short ItemVNum { get; set; }

        public abstract byte Amount { get; set; }

        public virtual long TransportId
        {
            get
            {
                if (_transportId == 0)
                {
                    // create transportId thru factory
                    _transportId = TransportFactory.Instance.GenerateTransportId();
                }

                return _transportId;
            }

            set
            {
                if (value != _transportId)
                {
                    _transportId = value;
                }
            }
        }

        #endregion

        #region Methods

        public string GenerateOut(long id)
        {
            return $"out 9 {id}";
        }

        public abstract ItemInstance GetItemInstance();

        #endregion
    }
}