using RPG.Combat;
using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _fighter = GetComponent<Fighter>();
        }

        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hitInfos = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hitInfo in hitInfos)
            {
                CombatTarget target = hitInfo.transform.GetComponent<CombatTarget>();
                if (!_fighter.CanAttack(target)) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    _fighter.Attack(target);
                }

                return true;
            }

            return false;
        }

        private bool InteractWithMovement()
        {
            if (Physics.Raycast(GetMouseRay(), out RaycastHit hitInfo, Mathf.Infinity))
            {
                if (Input.GetMouseButton(0))
                {
                    _mover.StartMoveAction(hitInfo.point);
                }

                return true;
            }

            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private Mover _mover;
        private Fighter _fighter;
    }
}
