using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_TickTack
{
    class TickTackTorModel
    {
        List<string> _area;
        bool _isCross;
        int _count;
        public TickTackTorModel()
        {
            _count = 0;
            _isCross = true;
            _area = new List<string>()
            {
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " "
            };
        }
        public string PlayerTurn(int index)
        {
            if (_area[index] == " ")
            {
                if (_isCross)
                    _area[index] = "X";
                else
                    _area[index] = "O";
                _isCross = !_isCross;
                _count++;
            }
            return _area[index];
        }

        public string CheckWinner()
        {
            if (isWinner())
            {
                if (_isCross)
                    return "Победили нолики";
                else
                    return "Победили крестики";
            }
            else if (_count >= 9)
                return "Ничья";
            return null;
        }
        private bool isWinner()
        {
            if (_area[0] == _area[1] && _area[1] == _area[2] && _area[2] != " ") return true;
            if (_area[3] == _area[4] && _area[4] == _area[5] && _area[5] != " ") return true;
            if (_area[6] == _area[7] && _area[7] == _area[8] && _area[8] != " ") return true;

            if (_area[0] == _area[3] && _area[3] == _area[6] && _area[6] != " ") return true;
            if (_area[1] == _area[4] && _area[4] == _area[7] && _area[7] != " ") return true;
            if (_area[2] == _area[5] && _area[5] == _area[8] && _area[8] != " ") return true;

            if (_area[0] == _area[4] && _area[4] == _area[8] && _area[8] != " ") return true;
            if (_area[2] == _area[4] && _area[4] == _area[6] && _area[6] != " ") return true;


            return false;
        }
    }
}
