using UnityEngine;
using MEC;
using Qurre.API;
using System.Collections.Generic;

namespace CatHook
{
    public class PhysicCore
    {
        internal static IEnumerator<float> Teleport(Player player)
        {
            Vector3 position = Getcampos(player.GameObject);
            if (position.x != 0 && player.Team != Team.SCP)
            {
                float startTime = Time.time;
                float duration = 5.0f;
                float t = (Time.time - startTime) / duration;
                float x = Mathf.SmoothStep(player.Position.x, position.x, t);
                float y = Mathf.SmoothStep(player.Position.y, position.y, t);
                float z = Mathf.SmoothStep(player.Position.z, position.z, t);
                float lx = x;
                float ly = y;
                float lz = z;
                for (int ok = 0; ok < 30;)
                {
                    t = (Time.time - startTime) / duration;
                    x = Mathf.SmoothStep(lx, position.x, t);
                    y = Mathf.SmoothStep(ly, position.y, t);
                    z = Mathf.SmoothStep(lz, position.z, t);
                    if (Vector3.Distance(position, new Vector3(lx, ly, lz)) > 1f && (lx != x || ly != y))
                    {
                        try
                        {
                            lx = x;
                            ly = y;
                            lz = z;
                            var pos = new Vector3(x, y, z);
                            if (!Physics.Linecast(player.Position, pos, player.Movement.CollidableSurfaces))
                            {
                                player.Position = pos;
                                ok = 0;
                            }
                            else ok = 30;
                        }
                        catch { }
                    }
                    else ok++;
                    yield return Timing.WaitForSeconds(0.01f);
                }
            }
        }
        internal static Vector3 Getcampos(GameObject gameObject)
        {
            Scp049_2PlayerScript component = gameObject.GetComponent<Scp049_2PlayerScript>();
            Scp106PlayerScript component2 = gameObject.GetComponent<Scp106PlayerScript>();

            Vector3 forward = component.plyCam.transform.forward;
            Physics.Raycast(component.plyCam.transform.position, forward, out RaycastHit raycastHit, 40f, component2.teleportPlacementMask);
            Vector3 position = raycastHit.point;

            if (gameObject.transform.position.y > raycastHit.point.y)
            {
                position = raycastHit.point + Vector3.up * 1f;
            }
            else if (gameObject.transform.position.y < raycastHit.point.y)
            {
                position = raycastHit.point + Vector3.down;
            }
            return position;
        }
    }
}