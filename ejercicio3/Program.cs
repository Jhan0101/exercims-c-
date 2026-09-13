static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        if (!knightIsAwake)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        if (knightIsAwake || archerIsAwake || prisonerIsAwake)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
         if (!archerIsAwake && prisonerIsAwake)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        if (petDogIsPresent)
        {
            if (!archerIsAwake)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (prisonerIsAwake && !knightIsAwake && !archerIsAwake)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
