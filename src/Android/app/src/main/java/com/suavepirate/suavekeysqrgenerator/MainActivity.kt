package com.suavepirate.suavekeysqrgenerator

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.snapchat.kit.sdk.SnapCreative
import com.snapchat.kit.sdk.creative.media.SnapLensLaunchData
import com.snapchat.kit.sdk.creative.models.SnapLensContent
import kotlinx.android.synthetic.main.activity_main.*


class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        lens_button.setOnClickListener {
            // Create a SnapLensContent object with LensID to be shared

            // Create a SnapLensContent object with LensID to be shared
            val snapLensContent = SnapLensContent("26b3d66e-4558-4081-9175-f51f7b4f6847")

            // Optionally build SnapLensLaunchData, add to snapLensContent

            // Optionally build SnapLensLaunchData, add to snapLensContent
//            val launchData = SnapLensLaunchData.Builder()
//                .addStringKeyPair("hair_color", "#b76e79")
//                .addStringKeyPair("hint", "lens_hint_raise_your_eyebrows")
//                .build()

//            snapLensContent.snapLensLaunchData = launchData

            // Optionally add an attachmentUrl and caption to the content

            // Optionally add an attachmentUrl and caption to the content
            snapLensContent.attachmentUrl = "https://snapchat.com"
            snapLensContent.captionText = "Check out this Snap Kit Lens!"

            // Use the SnapCreative API to share the snapLensContent

            // Use the SnapCreative API to share the snapLensContent
            val snapCreativeKitApi = SnapCreative.getApi(this)
            snapCreativeKitApi.send(snapLensContent)

            true
        }
    }
}
