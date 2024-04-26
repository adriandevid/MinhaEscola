'use client'
import useApplicationHook, { ApplicationHookProps } from "@/hooks/applicationHook";
import axios from "axios";
import { createContext } from "react"

export interface appContextProps extends ApplicationHookProps {
}

export const AplicationContext = createContext({} as appContextProps);

export function AppContextProvider({ children } : { children: any }) {
    const applicationHook = useApplicationHook();

    return (
        <AplicationContext.Provider value={{ ...applicationHook  }}>
            {children}
        </AplicationContext.Provider>
    )
}