'use client';

import { AplicationContext } from "@/contexts/appContext";
import { useContext, useEffect, useState } from "react";
import { IoIosArrowDown, IoIosArrowForward } from "react-icons/io";
import { LuClipboardCopy } from "react-icons/lu";

export const methodsResponse: any = {
    "post": "bg-green-700",
    "put": "bg-yellow-700",
    "delete": "bg-red-700",
    "get": "bg-blue-700"
  }
  
export default function DescriptionRequest({ method, router } : { method: string, router: any }) {
    const [open, isOpen] = useState<boolean>(false);
    const { apiDatas } = useContext(AplicationContext);

    useEffect(function () {
        isOpen(false);
    }, [router])
      
    return (
        <>
        <div className="bg-[#11171a] p-5 rounded-lg flex justify-between text-white items-center cursor-pointer z-10" onClick={() => { isOpen(!open); }}>
            <div><span className={`${methodsResponse[method]} rounded-lg pl-4 pr-4 pt-2 pb-2 text-white`}>{method.toUpperCase()}</span> <span className="text-white pl-2">{router.key}</span></div> {open ? <IoIosArrowDown /> : <IoIosArrowForward size={15} />}
        </div>
        {
            open ?
            <div className="bg-white p-5 w-full rounded-b-lg flex items-center gap-2 mt-[-3px] z-0"><LuClipboardCopy /><p className="text-sm/6">{apiDatas.servers[0].url}{router.key}</p></div> :
            <></>
        }
        </>
    )
}